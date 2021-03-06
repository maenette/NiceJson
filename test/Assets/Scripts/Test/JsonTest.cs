﻿using UnityEngine;
using System.Collections.Generic;
using System.IO;
using NiceJson;

public class JsonTest : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //ExampleTest();
        //UnicodeTest();
        //UnescapingTest();
        //UnicodeFileTest();

        //InputOutputFileTest();
        //CreateJsonTest();
        //SerializeObject();

        EmptyArrayTest();
        EmptyNodeTest();
    }

    private void ExampleTest()
    {
        JsonExample example = new JsonExample();
        Debug.Log("Test InputOutputFileTest done");
    }

    private void InputOutputFileTest()
    {
        string inputfile = "/Samples/sample.json";
        string outputPutfile = "/Samples/sample2.json";

        //Debug.Log("Reading file " + inputfile + " ...");

        string jsonString = File.ReadAllText("Assets/" + inputfile);

        //Debug.Log("Parse file");

        JsonNode node = JsonNode.ParseJsonString(jsonString);

        //Debug.Log("Saving file " + outputPutfile + " ...");

        File.WriteAllText("Assets/" + outputPutfile, node.ToJsonPrettyPrintString());

        Debug.Log("Test InputOutputFileTest done");
    }

    private void UnescapingTest()
    {
        string outputPutfile = "/Samples/unescapingSample.json";
        string stringJson = "{\"Unicode\": \"\\\"\u0010\n\",\"Url\":\"http:\\/\\/angelqm.com\"}";
        JsonNode node = JsonNode.ParseJsonString(stringJson);
        File.WriteAllText("Assets/" + outputPutfile, node.ToJsonPrettyPrintString());

        stringJson = File.ReadAllText("Assets/" + outputPutfile);
        node = JsonNode.ParseJsonString(stringJson);
        File.WriteAllText("Assets/" + outputPutfile, node.ToJsonPrettyPrintString());

        stringJson = File.ReadAllText("Assets/" + outputPutfile);
        node = JsonNode.ParseJsonString(stringJson);
        File.WriteAllText("Assets/" + outputPutfile, node.ToJsonPrettyPrintString());
    }

    private void UnicodeTest()
    {
        string outputPutfile = "/Samples/unicodeSample3.json";

        string stringJson = "{\"Unicode\":[ \"\u001F\" , \"\n\" , \"\b\" , \"\t\" , \"\f\" , \"\r\" ]}";

        JsonNode node = JsonNode.ParseJsonString(stringJson);
        File.WriteAllText("Assets/" + outputPutfile, node.ToJsonPrettyPrintString());

        string jsonString = File.ReadAllText("Assets/" + outputPutfile);
        JsonNode node2 = JsonNode.ParseJsonString(jsonString);
        File.WriteAllText("Assets/" + outputPutfile, node.ToJsonPrettyPrintString());
    }

    private void UnicodeFileTest()
    {
        string inputfile = "/Samples/unicodeSample.json";
        string outputPutfile = "/Samples/unicodeSample2.json";

        //Debug.Log("Reading file " + inputfile + " ...");

        string jsonString = File.ReadAllText("Assets/" + inputfile);

        //Debug.Log("Parse file");

        JsonNode node = JsonNode.ParseJsonString(jsonString);

        //Debug.Log("Saving file " + outputPutfile + " ...");

        File.WriteAllText("Assets/" + outputPutfile, node.ToJsonPrettyPrintString());

        Debug.Log("Test UnicodeFileTest done");
    }

    private void CreateJsonTest()
    {
        JsonArray weekDiet = new JsonArray();
        for(int i=0;i<7;i++)
        {
            JsonObject diet = new JsonObject();
            diet["DayNumber"] = i;
            diet["Breakfast"] = "Banana"+ i;
            diet["Lunch"] = "Banana"+ i;
            diet["Dinner"] = "Banana"+ i;
            diet["WithSugar"] = (i % 2 == 0);
            diet["RandomNumber"] = Random.Range(0f,1.5f);

            weekDiet.Add(diet);
        }

        for (int i=0;i<7;i++)
        {
            if (i % 2 == 1)
            {
                weekDiet[i]["RandomNumber"] = 3;
                weekDiet[i]["RandomNumber"] = weekDiet[i]["RandomNumber"] * 2f;
            }
        }

        Debug.Log("Test InputOutputFileTest done: \n"+ weekDiet.ToJsonPrettyPrintString());
    }

    private void EmptyArrayTest()
    {
        string inputfile = "/Samples/Save.json";
        string jsonString = File.ReadAllText("Assets/" + inputfile);
        Debug.Log(JsonNode.ParseJsonString(jsonString).ToJsonPrettyPrintString());
    }


    private void EmptyNodeTest()
    {
        string inputfile = "/Samples/Save2.json";
        string jsonString = File.ReadAllText("Assets/" + inputfile);
        Debug.Log(JsonNode.ParseJsonString(jsonString).ToJsonPrettyPrintString());
    }

    private void SerializeObject()
    {
        object testObject = new List<string>();

        //JsonFormatter formatter = new JsonFormatter();
        //formatter.Serialize(testObject);
    }

    private void DeserializeObject()
    {

    }

}