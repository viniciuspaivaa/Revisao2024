Random random = new Random();
int size, i, z;
bool special = false;
bool num = false;
bool letter = false;
bool error = false;
string hange = "";
string password = "";

Console.Clear();

Console.Write("Digite a quantidade de caracteres: ");
while(!int.TryParse(Console.ReadLine(), out size) || size < 6)
{
    Console.Write("Número inválido! Digite novamente: ");
}

Console.Clear();

Console.Write("A senha deverá ter caracteres especiais?\n\n1. Sim\n2. Não\n\nSua resposta: ");
while(!int.TryParse(Console.ReadLine(), out i) || i > 2 || i < 0)
{
    Console.Write("Número inválido! Digite novamente: ");
}
special = i == 1 ? true : false;

Console.Clear();

Console.Write("A senha deverá ter número?\n\n1. Sim\n2. Não\n\nSua resposta: ");
while(!int.TryParse(Console.ReadLine(), out i) || i > 2 || i < 0)
{
    Console.Write("Número inválido! Digite novamente: ");
}
num = i == 1 ? true : false;

Console.Clear();

Console.Write("A senha deverá ter letras?\n\n1. Sim\n2. Não\n\nSua resposta: ");
while(!int.TryParse(Console.ReadLine(), out i) || i > 2 || i < 0)
{
    Console.Write("Número inválido! Digite novamente: ");
}
letter = i == 1 ? true : false;

Console.Clear();

string charSpecial = "!@#$%&*()_+={}[]^~:><.,";
string charNum = "0123456789";
string charLetter = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

hange += special ? charSpecial : "";
hange += num ? charNum : "";
hange += letter ? charLetter : "";

char[] hangeArray = hange.ToCharArray();

do
{
    for(z = 0; z < size; z++)
    {
        int a = random.Next(0, hangeArray.Length);
        password += hangeArray[a];
    }

    error = special && password.Any(p => charSpecial.Contains(p)) && num && password.Any(p => charNum.Contains(p)) && letter && password.Any(p => charLetter.Contains(p)) ? false : true;
    if(error)
    {
        password="";
        z = 0;    
    }
}while(error);

// File.WriteAllText("bkp.txt", password);
File.AppendAllText("bkp.txt", password + Environment.NewLine);
Console.Write("Senha gerada: " + password);
