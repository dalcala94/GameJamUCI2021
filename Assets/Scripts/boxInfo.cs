﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxInfo : MonoBehaviour
{
    //To address
    [System.NonSerialized]
    public string toCity;
    [System.NonSerialized]
    public string toStreet;
    [System.NonSerialized]
    public string toHouseNum;
    [System.NonSerialized]
    public string toZipNum;

    //From address
    [System.NonSerialized]
    public string fromCity;
    [System.NonSerialized]
    public string fromStreet;
    [System.NonSerialized]
    public string fromHouseNum;
    [System.NonSerialized]
    public string fromZipNum;

    //First name
    [System.NonSerialized]
    public string firstName;
    //Last name
    [System.NonSerialized]
    public string lastName;

    //get boxManager
    private boxManager manage;

    //list of all the info for the box
    [System.NonSerialized]
    public List<string> mailBox = new List<string> { };

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("BoxSpawner");
        manage = temp.GetComponent<boxManager>();

        sprite = GetComponent<SpriteRenderer>();

        mailBox.Add(CreateRandomName());
        mailBox.Add(CreateRandomHomeAddressTo());
        mailBox.Add(CreateRandomHomeAddressFrom());

        sprite.sprite = manage.boxSprites[CreateRandomNumber(manage.boxSprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CreateRandomNumber(int range)
    {
        return Random.Range(0, range);
    }

    public string CreateRandomName()
    {
        //create first and last names
        firstName = manage.firstNamesList[CreateRandomNumber(manage.firstNamesList.Length)];
        lastName = manage.lastNamesList[CreateRandomNumber(manage.lastNamesList.Length)];
        return "To: " + firstName + " " + lastName;
    }

    public string CreateRandomHomeAddressTo()
    {
        toCity = manage.citiesList[CreateRandomNumber(manage.citiesList.Length)];
        toStreet = manage.streetsList[CreateRandomNumber(manage.streetsList.Length)];
        
        int length = Random.Range(1, 6);
        string totalAddressTo = "";
        for (int i = 0; i < length; i++)
        {
            totalAddressTo += Random.Range(0, 10).ToString();
        }        

        string totalZipTo = "";
        for (int i = 0; i < 5; i++)
        {
            totalZipTo += Random.Range(0, 10).ToString();
        }
        return totalAddressTo + " " + toStreet + ", " + toCity + " " + totalZipTo;               
    }

    public string CreateRandomHomeAddressFrom()
    {
        fromCity = manage.citiesList[CreateRandomNumber(manage.citiesList.Length)];
        fromStreet = manage.streetsList[CreateRandomNumber(manage.streetsList.Length)];

        int length = Random.Range(1, 6);
        string totalAddressFrom = "";
        for (int i = 0; i < length; i++)
        {
            totalAddressFrom += Random.Range(0, 10).ToString();
        }

        string totalZipFrom = "";
        for (int i = 0; i < 5; i++)
        {
            totalZipFrom += Random.Range(0, 10).ToString();
        }
        return "From: " + totalAddressFrom + " " + fromStreet + ", " + fromCity + " " + totalZipFrom;
    }

    public string GetName()
    {
        //return "Rigel Kuper";
        
        return mailBox[0];
    }

    public string GetTo()
    {
        return mailBox[1];
    }

    public string GetFrom()
    {
        return mailBox[2];
    }
}
