using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MejoresJugadores : MonoBehaviour
{
    private readonly MongoClient cliente = new MongoClient("mongodb+srv://Johan:Johan@dbloginreact.2ljvu.mongodb.net/?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> coleccion;

    public TextMeshProUGUI textoMejoresPuntuacion;
    public TextMeshProUGUI textoMejoresNombres;
    // Start is called before the first frame update
    void Start()
    {
        database = cliente.GetDatabase("AventurasMexicanas");
        coleccion = database.GetCollection<BsonDocument>("nivel_dos");
        mejoresJugadores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void mejoresJugadores()
    {

        var mejoresJugadores = coleccion.Find(new BsonDocument()).Sort(Builders<BsonDocument>.Sort.Descending("puntos")).Limit(5).ToList();
        textoMejoresPuntuacion.text += "\n";
        textoMejoresNombres.text += "\n";
        mejoresJugadores.ForEach(data =>
        {   
            //data["puntos"].AsInt64;    
            textoMejoresPuntuacion.text +=  data["puntos"].AsInt32.ToString() + "\n";
            textoMejoresNombres.text += data["nombreJugador"].AsString.ToString() + "\n";
        }); 
    }

    public void salir()
    {
        SceneManager.LoadScene("Menu-v2");
    }
}
