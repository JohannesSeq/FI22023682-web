
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.VisualBasic.FileIO;
using Microsoft.EntityFrameworkCore;


using var db = new bibliotecaContext();

//Validacion si hay datos en la DB
if (!db.Title.Any())
{
    // The table is empty
    Console.WriteLine("La base de datos está vacía, por lo que será llenada a partir de los datos del archivo CSV.");
    

    int indiceAutor = 1;
    int indiceTag = 1;
    int indiceTitle = 1;
    int indiceTitleTag = 0;

    Author CurrentAuthor = null;
    Title CurrentTitle = null;
    Tag CurrentTag = null;

    string RutaCSV = "../data/bookst.csv";

    using (TextFieldParser LectorCSV = new TextFieldParser(@"../data/books.csv"))
    {
        LectorCSV.TextFieldType = FieldType.Delimited;
        LectorCSV.SetDelimiters(",");
        while (!LectorCSV.EndOfData)
        {
            string[] CSVImportado = LectorCSV.ReadFields();
            int n = 0;


            foreach (string Columna in CSVImportado)
            {
                if (!Columna.Equals("Author") && !Columna.Equals("Title") && !Columna.Equals("Tags"))
                {
                    if (n == 0)
                    {

                        CurrentAuthor = db.Author.FirstOrDefault(a => a.AuthorName == Columna);

                        if (CurrentAuthor == null)
                        {
                            if (db.Author.Any())
                            {
                                indiceAutor += 1;
                            }

                            CurrentAuthor = new Author { AuthorId = indiceAutor, AuthorName = Columna };

                            db.Add(CurrentAuthor);
                            await db.SaveChangesAsync();

                        }

                    }

                    else if (n == 1)
                    {
                        CurrentTitle = db.Title.FirstOrDefault(t => t.TitleName == Columna);

                        if (CurrentTitle == null)
                        {

                            if (db.Title.Any())
                            {
                                indiceTitle += 1;
                            }

                            CurrentTitle = new Title { TitleId = indiceTitle, TitleName = Columna, author = CurrentAuthor };
                            db.Add(CurrentTitle);

                            await db.SaveChangesAsync();
                        }

                    }

                    else if (n == 2)
                    {
                        //Console.WriteLine(n + "; Categoria: " + Columna);

                        string[] TagSep = Columna.Split("|");

                        List<Tag> TagArray = new List<Tag>();

                        foreach (string TagS in TagSep)
                        {
                            CurrentTag = db.Tag.FirstOrDefault(t => t.TagName == TagS);

                            if (CurrentTag == null)
                            {
                                if (db.Tag.Any())
                                {
                                    indiceTag += 1;
                                }
                                CurrentTag = new Tag { TagId = indiceTag, TagName = TagS };
                                db.Add(CurrentTag);
                                await db.SaveChangesAsync();

                            }
                            TagArray.Add(CurrentTag);
                        }

                        //Codigo del title tag

                        List<TitleTag> TitleTagArray = new List<TitleTag>();

                        foreach (Tag TagT in TagArray)
                        {
                            indiceTitleTag += 1;

                            TitleTag NTitleTag = new TitleTag { TitleTagId = indiceTitleTag, tag = TagT, title = CurrentTitle };

                            db.Add(NTitleTag);
                            await db.SaveChangesAsync();

                            TitleTagArray.Add(NTitleTag);

                        }

                        CurrentTitle.TitleTags = TitleTagArray;
                        db.SaveChanges();

                        foreach (Tag iTag in TagArray)
                        {
                            //iTag.TitleTags = TitleTagArray;
                            //db.SaveChanges();
                        }


                    }
                }
                n++;
            }

        }
    }
    Console.WriteLine("Procesando... Listo.");
}


else
{
    Console.WriteLine("La base de datos se está leyendo para crear los archivos TSV.");
    int TotalTitulos = db.Title.Count();
    Title TituloLectura = null;
    Author AutorLectura = null;

    List<String> TSVArray = new List<String>();


    String TSVLine = "";

    var Titulos = db.Title
        .Include(t => t.author)
        .Include(t => t.TitleTags)
        .ThenInclude(tt => tt.tag)
        .ToList();

    foreach (var t in Titulos)
    {
        foreach (TitleTag tt in t.TitleTags)
        {


            TSVLine = t.author.AuthorName + "\t" + t.TitleName + "\t" + tt.tag.TagName + "\n";

            if (TSVArray.Count == 0)
            {
                TSVArray.Add(TSVLine);
            }
            else
            {
                for (int i = 0; i < TSVArray.Count(); i++)
                {

                    if (TSVArray[i].StartsWith(TSVLine[0]))
                    {
                        TSVArray[i] += TSVLine;
                    }
                    else if (i == TSVArray.Count() - 1)
                    {
                        TSVArray.Add(TSVLine);
                    }
                }

            }

        }
    }

    for (int i = 0; i < TSVArray.Count(); i++)
    {
        String TSVPath = "../data/";
        String FileName = TSVArray[i][0].ToString() + ".tsv";
        TSVArray[i] = "AuthorName\tTitleName\tTagName\n" + TSVArray[i];
        File.WriteAllText(Path.Combine(TSVPath, FileName), TSVArray[i]);

    }
    Console.WriteLine("Procesando... Listo.");

}
