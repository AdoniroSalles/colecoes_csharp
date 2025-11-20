using System.Collections;

var musica1 = new Musica
{
    Titulo = "Imagine",
    Artista = "John Lennon",
    Duracao = 183
};

var musica2 = new Musica
{
    Titulo = "Bohemian Rhapsody",
    Artista = "Queen",
    Duracao = 354
};
var musica3 = new Musica
{
    Titulo = "Hotel California",
    Artista = "Eagles",
    Duracao = 391
};
var musica4 = new Musica
{
    Titulo = "Billie Jean",
    Artista = "Michael Jackson",
    Duracao = 294
};
var musica5 = new Musica
{
    Titulo = "Smells Like Teen Spirit",
    Artista = "Nirvana",
    Duracao = 301
};

var rockNacional = new Playlist
{
    Nome = "Rock Nacional"
};

//add músicas à playlist    
rockNacional.Add(musica1);
rockNacional.Add(musica2);
rockNacional.Add(musica3);
rockNacional.Add(musica4);
rockNacional.Add(musica5);

Playlist(rockNacional);

var musicaEncontrada = rockNacional.ObterPeloTitulo("Imagine");
if (musicaEncontrada is not null)
{
    Console.WriteLine("\nRemovendo música...");
    rockNacional.Remove(musicaEncontrada);
}
else
{
    Console.WriteLine("\n Música não encontrada.");
}

Playlist(rockNacional);

var musicaALeatoria = rockNacional.ObterAleatoria();
if (musicaALeatoria is not null)
{
    Console.WriteLine($"\nA música aleatória é {musicaALeatoria.Titulo}");
}
else
{
    Console.WriteLine("\nA playlist está vazia.");
}

    void Playlist(Playlist playlist)
    {
        Console.WriteLine($"\n Tocans as músicas de {playlist.Nome}");
        foreach (var musica in playlist)
        {
            Console.WriteLine($" - {musica.Titulo}, {musica.Artista}, {musica.Duracao}s");
        }
    }

class Musica
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public int Duracao { get; set; }

}

class Playlist : ICollection<Musica>
{
    private List<Musica> list = [];
    public string Nome { get; set; }

    public int Count => list.Count;

    public bool IsReadOnly => false;

    public Musica? ObterPeloTitulo(string titulo)
    {
        foreach (var musica in list)
        {
            if (musica.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                return musica;
        }
        return null;
    }

    public Musica? ObterAleatoria()
    {
        if (list.Count() == 0) return null;

        var random = new Random();
        var numeroAleatorio = random.Next(0, list.Count -1);
        return list[numeroAleatorio];
    }
    public void Add(Musica item)
    {
        list.Add(item);
    }

    public void Clear()
    {
        list.Clear();
    }

    public bool Contains(Musica item)
    {
        return list.Contains(item);
    }

    public void CopyTo(Musica[] array, int arrayIndex)
    {
        list.CopyTo(array, arrayIndex);
    }

    public IEnumerator<Musica> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    public bool Remove(Musica item)
    {
        return list.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

