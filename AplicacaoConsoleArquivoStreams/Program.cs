

using static System.Console;


var destino = Path.Combine("C:\\Amauri\\Projeto\\AplicacaoConsoleArquivoStreams\\AplicacaoConsoleArquivoStreams", "Entrada", "arquivo.csv");
 
using var sr = new StreamReader(destino);
var cabecalho = sr.ReadLine()?.Split(';');
while (true)
{
    var registro = sr.ReadLine()?.Split(';');
    if (registro == null) break;
    for (int i = 0; i < registro.Length; i++)
    {
        Console.WriteLine($"{cabecalho?[i]}:{registro[i]}");
    }
    Console.WriteLine("............................");
}
Console.WriteLine("\n\n ............................");
ReadLine();


//using System.Text;

//StringBuilder sb = new StringBuilder();
//sb.AppendLine("Primeira linha");
//sb.AppendLine("segunda linha");
//sb.AppendLine("terceira linha");

//StringReader sr = new StringReader(sb.ToString());
//var buffer = new char[10];
//var pos = sr.Read(buffer);
//var texto = sr.ReadToEnd();




/*
using System.IO;
using System.Runtime;


var path = Path.Combine("C:\\Amauri\\Projeto\\AplicacaoConsoleArquivoStreams", "globo");
using var fsw = new FileSystemWatcher(path);

fsw.Created += OnCreated;
fsw.Renamed += OnRenamed;
fsw.Deleted += OnDeleted;

fsw.EnableRaisingEvents= true;
fsw.IncludeSubdirectories= true;

Console.WriteLine("Pressione o enter para finaloizar");

Console.ReadLine(); //só termina quando der o enter



void OnDeleted(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"Foi deletado o arquivo {e.Name}");
}

void OnRenamed(object sender, RenamedEventArgs e)
{
    Console.WriteLine($"Foi renomeado o arquivo {e.OldName} para o {e.Name}");
}

void OnCreated(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"Foi criado o arquivo {e.Name}");
}

 

//var path = Path.Combine("C:\\Amauri\\Projeto\\AplicacaoConsoleArquivoStreams", "globo");
//LerArquivo( path);
//LerDiretorios(path);

static void LerArquivo(string path)
{
    var arquivos = Directory.GetFiles(path,"*.txt",SearchOption.AllDirectories);
    foreach (var arquivo in arquivos)
    {
        var fileinfo = new FileInfo(arquivo);
        Console.WriteLine($"[Nome]:{fileinfo.Name}");
        Console.WriteLine($"[Tamanho]:{fileinfo.Length}");
        Console.WriteLine($"[Ultimo Acesso]:{fileinfo.LastAccessTime}");
        Console.WriteLine($"[Pasta]:{fileinfo.Directory}");
        Console.WriteLine("............................");
    }
}

static void LerDiretorios(string path)
{
    if (!File.Exists(path))
    {
        Console.WriteLine("..............Diretorio não existe..............");
        return;
    }
    else
    { 
        var diretorios = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
        foreach (var dir in diretorios)
        {
            var dirInfo = new DirectoryInfo(dir);
            Console.WriteLine($"[Nome]:{dirInfo.Name}");
            Console.WriteLine($"[Raiz]:{dirInfo.Root}");
            if (dirInfo.Parent != null)
                Console.WriteLine($"[Pai]:{dirInfo.Parent.Name}");

            Console.WriteLine("................");
        }
    }
}

*/


/*
using static System.Console;

CriarDiretorios();
CriarArquivo();

var origem = Path.Combine("C:\\Amauri\\Projeto\\AplicacaoConsoleArquivoStreams", "Brasil.txt");
var destino = Path.Combine("C:\\Amauri\\Projeto\\AplicacaoConsoleArquivoStreams", "globo", "America do sul", "Brasil", "Brasil.txt");

MoverArquivo(origem, destino);



static void MoverArquivo(string pathOrigem, string pathDestino)
{
    if (!File.Exists(pathOrigem))
    {
        Console.WriteLine("Arquivo de origem não existe");
        return;
    }


    if (File.Exists(pathOrigem))
    {
        Console.WriteLine("Arquivo de destino já existe");
        return;
    }


    File.Move(pathOrigem, pathDestino); 
}


static void CriarArquivo()
{
    var pach = Path.Combine("C:\\Amauri\\Projeto\\AplicacaoConsoleArquivoStreams", "Brasil.txt"); //(Environment.CurrentDirectory, "teste.txt");
    if (!File.Exists(pach))
    {
        using var sw = File.CreateText(pach);
        sw.WriteLine("populoção djhfkjsdfhkjsdfhkjs");
        sw.WriteLine("Coisas do dkgjfkg");
        File.Create(pach);
    }
}







static void CriarDiretorios()
{
    //criar o diretorio
    var path = Path.Combine("C:\\Amauri\\Projeto\\AplicacaoConsoleArquivoStreams", "globo");
    if (!Directory.Exists(path))
    {
        var diretorioGlobo = Directory.CreateDirectory(path);
        //Criação de subdiretorio
        var subDirN = diretorioGlobo.CreateSubdirectory("America do norte");
        var subDirC = diretorioGlobo.CreateSubdirectory("America do central");
        var subDirS = diretorioGlobo.CreateSubdirectory("America do sul");
        //Criação paises
        subDirN.CreateSubdirectory("USA");
        subDirN.CreateSubdirectory("Canada");

        subDirC.CreateSubdirectory("Panama");

        subDirS.CreateSubdirectory("Brasil");
        subDirS.CreateSubdirectory("Argentina");
        subDirS.CreateSubdirectory("Uruguay");
    }
}

*/




/*



//var pach = Path.Combine("C:\\Amauri\\Projeto\\AplicacaoConsoleArquivoStreams", "teste.txt"); //(Environment.CurrentDirectory, "teste.txt");

//File.Create(pach);
//Console.WriteLine("Arquivo criado em: C:\\Amauri\\Projeto\\AplicacaoConsoleArquivoStreams");


//using(var a = File.CreateText(pach))
//{
//    a.WriteLine("Linha1");
//    a.WriteLine("Linha 2");
//    a.WriteLine("Linha 3");
//    a.WriteLine("Linha 4");
//    a.Flush();

//}



using static System.Console;

WriteLine("Digite o nome do arquivo: ");

var nome = ReadLine();
nome = LimpaCaracteresInvalidos(nome);

//criar o arquivo
var path = Path.Combine("C:\\Amauri\\Projeto\\AplicacaoConsoleArquivoStreams", $"{nome}.txt");


CriarArquivo(path);

WriteLine("Digite enter para finalizar....");
ReadLine();



static string LimpaCaracteresInvalidos(string texto)
{

    foreach (var caracter in Path.GetInvalidFileNameChars())
    {
        texto = texto.Replace(caracter, '_');
    }
    return texto;

}

static void CriarArquivo(string caminho)
{
	try
	{
        var arquivo = File.CreateText(caminho);
        arquivo.WriteLine("Linha1");
        arquivo.WriteLine("Linha 2");
        arquivo.WriteLine("Linha 3");
        arquivo.WriteLine("Linha 4");
    }
	catch (Exception ex)
	{
        WriteLine("Arquivo com problema " + ex.Message.ToString());
    }

}




*/
