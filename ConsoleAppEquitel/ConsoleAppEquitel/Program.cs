
using ConsoleAppEquitel.Core;
using System.Configuration;
using System.Text;

void ProcessFile()
{
    FileCore file = new FileCore();

    Task.Run(() =>
    {
        file.ItemUno();
    });

    Task.Run(() =>
    {
        file.ItemDos();
    });

    Task.Run(() =>
    {
        file.ItemTres();
    });

    Task.Run(() =>
    {
        file.ItemCuatro();
    });
}

ProcessFile();

Console.ReadLine();



