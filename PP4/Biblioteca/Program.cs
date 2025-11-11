
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

using var db = new bibliotecaContext();

//Validacion si hay datos en la DB
if (!db.Title.Any())
{
    // The table is empty
    Console.WriteLine("La base de datos está vacía, por lo que será llenada a partir de los datos del archivo CSV.");
    Console.WriteLine("Procesando... Listo.");

    int indiceAutor = 1;
    int indiceTag = 1;
    int indiceTitle = 1;
    int indiceTitleTag = 1;

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
            //Processing row
            string[] CSVImportado = LectorCSV.ReadFields();
            //var Autores = new List<string>();
            int n = 0;


            foreach (string Columna in CSVImportado)
            {
                if (!Columna.Equals("Author") && !Columna.Equals("Title") && !Columna.Equals("Tags"))
                {
                    if (n == 0)
                    {

                        Console.WriteLine(n + "; Autor: " + Columna);
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
                        Console.WriteLine(n + "; Libro: " + Columna);
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
                        Console.WriteLine(n + "; Categoria: " + Columna);

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

                        //Leer el array de todos los tags

                        foreach (Tag TagT in TagArray)
                        {
                            indiceTitleTag += 1;
                            TitleTag NTitleTag = new TitleTag { TitleTagId = indiceTitleTag, tag = TagT, title = CurrentTitle };
                            db.Add(NTitleTag);
                            await db.SaveChangesAsync();
                        }

                        //Leer el current title

                        //Montar el query

                    }
                    n++;

                }
            }

        }
    }
}





else
{
    Console.WriteLine("La base de datos se está leyendo para crear los archivos TSV.");
    Console.WriteLine("Procesando... Listo.");
}



Console.WriteLine("Procesando... Listo.");