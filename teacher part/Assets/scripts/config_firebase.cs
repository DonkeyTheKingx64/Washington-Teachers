using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

//this is basically the teacher half (pushing to the database)
//we're using firebase realtime database in this project
//and the rest client api (makes it easier to build for other
//platforms too)
public class config_firebase : MonoBehaviour
{
    //the class' name, eg: CSE 143
    public static string class_name;
    
    //the title of the announcement to be made
    public static string title;
    
    //the actual announcement
    public static string content;

    //serialized fields allow us to refer to other objects in the inspector
    //without making the fields public

    //the text object that displays the class' name 
    [SerializeField] private Text class_name_text1;

    //the text object that displays the title 
    [SerializeField] private Text title_text1;

    //the text object that displays the content
    [SerializeField] private Text content_text1;

    [SerializeField] private Text sent;

    private void Start()
    {
        sent.text = " ";
    }

    //this gets called when the teacher half of the app hits the submit button
    public void OnSubmit() {
        class_name = class_name_text1.text;
        title = title_text1.text;
        content = content_text1.text;
        GoToDatabase();
    }

    //this gets called when the teacher half of the app hits the submit button
    private void GoToDatabase() {
        announcement anc = new announcement();
        //structures the json databse like so:
        /* root
         *  | |_ class name
         *  |     | |_ title of the first announcement
         *  |     |       |_ details of this announcement
         *  |     |___ title of the next announcement
         *  |             |_ details of this one
         *  |____ another class
         *        .
         *        .
         *        .
         */
        RestClient.Put("https://final-project-1e038.firebaseio.com/"+class_name.ToUpper()+"/"+title+".json", anc);
        sent.text = "sent!";
    }  
}
