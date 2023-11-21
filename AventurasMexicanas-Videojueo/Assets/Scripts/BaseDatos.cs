using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDatos : MonoBehaviour
{
    private readonly MongoClient cliente = new MongoClient("mongodb+srv://Johan:Johan@dbloginreact.2ljvu.mongodb.net/?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> coleccion;
    // Start is called before the first frame update
    void Start()
    {

        database = cliente.GetDatabase("AventurasMexicanas");
        coleccion = database.GetCollection<BsonDocument>("nivel_dos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void guardarPuntosBaseDatos(int puntos)
    {
        var documento = new BsonDocument { { "puntos", puntos } };
        await coleccion.InsertOneAsync(documento);
    }
}
