using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prompt : MonoBehaviour
{

    public string message;
    public bool showGui;
    public GameObject Text;
    //public AudioSource Audio;
    
    public MeshRenderer meshRenderer;
    public float speed = .5f;
    private float t = 0.0f;
    public float cuttoff=0.0f;
    public float finalDissolve = 0.0f;
    public float unlocking = 0.0f;
    public bool dissolve = false;
    public bool finalLevel = false;
    public bool unlock = false;
    public MeshRenderer door;
    public MeshRenderer key;
    public MeshRenderer finalWords;
    public MeshRenderer finalGate;
    public MeshRenderer bad;
    //public MeshRenderer Rembran;
    public MeshRenderer Kleimt;
    public TextMeshPro Words;
    public Animator gatekeep;
    public AudioClip final;
    public AudioClip findMeArtist;
    public AudioClip finalFindMeArtist;
    public AudioClip leave;
    public AudioClip thanks;
    public string stolenArtFirst;
    public string StolenArtFinall;

    public MeshRenderer RemA;
    public MeshRenderer Remb;
    public MeshRenderer Klempt;

    public MeshRenderer Jean_Metzinger;
    public MeshRenderer Les_Huîtres;
    public MeshRenderer Max_Liebermann;
    public MeshRenderer Raphael_missing;
    public MeshRenderer Vermeer_The_concert;

    public AudioClip JMAudio;
    public AudioClip LESAudio;
    public AudioClip MAXAudio;
    public AudioClip RAPAudio;
    public AudioClip VERAudio;

    public AudioClip badClip;

    public MeshRenderer Edgar;
    public MeshRenderer Hilaire;
    public MeshRenderer Van;
    public MeshRenderer Ren;
    public MeshRenderer Klim;

    public AudioClip EgAudio;
    public AudioClip HilAudio;
    public AudioClip VanAudio;
    public AudioClip RenAudio;
    public AudioClip KlimAudio;

    public string[] StolenArtFinal;


    private string[] StolenArt;

    private void Start()
    {

       

        AudioSource audio = GetComponent<AudioSource>();
        Animator gatekeep= gameObject.GetComponent<Animator>();

        StolenArtFinal = new string[]
            {
                 "The_Chorus_1876_Edgar_Degas",
                 "Edgar_Germain_Hilaire_Degas_053",
                 "Van_Gogh_-_Der_Maler_auf_dem_Weg_zur_Arbeit",
                 "Auguste_Renoir_Conversation",
                 "Gustav_Klimt,_1907,_Adele_Bloch-Bauer_I,_Neue_Galerie_New_York",
            };

        StolenArt = new string[]
             {
                 "Jean_Metzinger,_1911-12,_Man_with_a_Pipe_(Portrait_of_an_American_Smoker",
                 "Les_Huîtres_-_Jacob_Ochtervelt",
                 "Max_Liebermann_-_Zwei_Reiter_am_Strand",
                 "Raphael_missing",
                 "Vermeer_The_concert",
             };
        stolenArtFirst = StolenArt[Random.Range(0, StolenArt.Length)];

        StolenArtFinall = StolenArtFinal[Random.Range(0, StolenArtFinal.Length)];

       /* for (int i=0; i<StolenArtFinal.Length;i++)
        {
            if (StolenArtFinal[i]==StolenArtFinall)
            {

            }
        }*/

        if (StolenArtFinall== "The_Chorus_1876_Edgar_Degas")
            {
                StolenArtFinall = "Edgar Degas' 'TheChorus'!";
                finalFindMeArtist = EgAudio;
                Edgar.gameObject.tag = "Win";
                Hilaire.gameObject.tag = "Bad";
                Van.gameObject.tag = "Bad";
                Ren.gameObject.tag = "Bad";
                Klim.gameObject.tag = "Bad";
            }

        if (StolenArtFinall == "Edgar_Germain_Hilaire_Degas_053")
            {
                StolenArtFinall = "Hilaire Degas' 'Edgar Germai'!";
                Hilaire.gameObject.tag = "Win";
                finalFindMeArtist = HilAudio;
                Edgar.gameObject.tag = "Bad";
                Van.gameObject.tag = "Bad";
                Ren.gameObject.tag = "Bad";
                Klim.gameObject.tag = "Bad";
            }
        if (StolenArtFinall == "Van_Gogh_-_Der_Maler_auf_dem_Weg_zur_Arbeit")
            {
                StolenArtFinall = "Van Gogh's 'Der Maler auf dem Weg zur Arbeit'!";
                Van.gameObject.tag = "Win";
                finalFindMeArtist = VanAudio;
                Edgar.gameObject.tag = "Bad";
                Hilaire.gameObject.tag = "Bad";
                Ren.gameObject.tag = "Bad";
                Klim.gameObject.tag = "Bad";
            }

        if (StolenArtFinall == "Auguste_Renoir_Conversation")
            {
                StolenArtFinall = "Renoir's 'Conversation'!";
                Ren.gameObject.tag = "Win";
                finalFindMeArtist = RenAudio;
                Edgar.gameObject.tag = "Bad";
                Hilaire.gameObject.tag = "Bad";
                Van.gameObject.tag = "Bad";
                Klim.gameObject.tag = "Bad";
            }
        if (StolenArtFinall == "Gustav_Klimt,_1907,_Adele_Bloch-Bauer_I,_Neue_Galerie_New_York")
            {
                StolenArtFinall = "Gustav Klimt's 'Adele Bloch-Bauer'!";
                Klim.gameObject.tag = "Win";
                finalFindMeArtist = KlimAudio;
                Edgar.gameObject.tag = "Bad";
                Hilaire.gameObject.tag = "Bad";
                Van.gameObject.tag = "Bad";
                Ren.gameObject.tag = "Bad";
            }
        
        if (stolenArtFirst == "Jean_Metzinger,_1911-12,_Man_with_a_Pipe_(Portrait_of_an_American_Smoker")
            {
                stolenArtFirst = "Jean Metzinger's 'Man with a Pipe'!";
                Jean_Metzinger.gameObject.tag = "Key";
                finalWords = Jean_Metzinger;
                findMeArtist = JMAudio;
                Les_Huîtres.gameObject.tag = "Bad";
                Raphael_missing.gameObject.tag = "Bad";
                Max_Liebermann.gameObject.tag = "Bad";
                Vermeer_The_concert.gameObject.tag = "Bad";
        }
           
        if (stolenArtFirst == "Les_Huîtres_-_Jacob_Ochtervelt")
            {
                stolenArtFirst = "Jacob Ochtervelt's 'Les Huîtres'! ";
                Les_Huîtres.gameObject.tag = "Key";
                finalWords = Les_Huîtres;
                findMeArtist = LESAudio;
                Jean_Metzinger.gameObject.tag = "Bad";
                Raphael_missing.gameObject.tag = "Bad";
                Max_Liebermann.gameObject.tag = "Bad";
                Vermeer_The_concert.gameObject.tag = "Bad";
        }

        if (stolenArtFirst == "Max_Liebermann_-_Zwei_Reiter_am_Strand")
            {
                stolenArtFirst = "Max Liebermann's 'Zwei Reiter am Strand'! ";
                Max_Liebermann.gameObject.tag = "Key";
                finalWords = Max_Liebermann;
                findMeArtist = MAXAudio;
                Les_Huîtres.gameObject.tag = "Bad";
                Jean_Metzinger.gameObject.tag = "Bad";
                Raphael_missing.gameObject.tag = "Bad";
                Vermeer_The_concert.gameObject.tag = "Bad";
            }
            
        if (stolenArtFirst == "Raphael_missing")
            {
                stolenArtFirst = "Raphael's missing work! ";
                Raphael_missing.gameObject.tag = "Key";
                finalWords = Raphael_missing;
                findMeArtist = RAPAudio;
                Les_Huîtres.gameObject.tag = "Bad";
                Jean_Metzinger.gameObject.tag = "Bad";
                Max_Liebermann.gameObject.tag = "Bad";
                Vermeer_The_concert.gameObject.tag = "Bad";
            }

        if (stolenArtFirst == "Vermeer_The_concert")
            {
                stolenArtFirst = "Vermeer's 'The Concert'! ";
                Vermeer_The_concert.gameObject.tag = "Key";
                finalWords = Vermeer_The_concert;
                findMeArtist = VERAudio;
                Les_Huîtres.gameObject.tag = "Bad";
                Jean_Metzinger.gameObject.tag = "Bad";
                Raphael_missing.gameObject.tag = "Bad";
                Max_Liebermann.gameObject.tag = "Bad";
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rembrandt")
        {
           /* if (other.gameObject == RemA)
                {
                    Rembran = RemA;
                }
            if (other.gameObject == Remb)
                {
                    Rembran = Remb;
                }*/
            Kleimt = Klempt;
            Text.gameObject.SetActive(true);
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = thanks;
            audio.Play();
            
            Words.text = "Now go find me: "+ stolenArtFirst;
            audio.clip = findMeArtist;
            audio.Play();
            dissolve = true;
        }
        if (other.gameObject.tag=="Key")
        {
            
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = final;
            audio.Play();
            audio.clip = finalFindMeArtist;
            audio.Play();
            finalLevel = true;
            Words.text = "Final task:" + StolenArtFinall;

            gatekeep.SetTrigger("Final");


        }
        if (other.gameObject.tag == "Win")
        {

            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = leave;
            audio.Play();
            unlock = true;
            Words.text = "You found it!";

            gatekeep.SetTrigger("Win");


        }

        if (other.gameObject.tag == "Bad")
        {

            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = badClip;
            audio.Play();
            
            Words.text = "That's not it! Keep looking!";

 


        }
    }

    void Update()
    {
        if (dissolve)
        {
            Material[] mats = meshRenderer.materials;

            
            if (cuttoff < 1)
            {
                mats[0].SetFloat("_Cutoff", cuttoff += .0051f);
                t += Time.deltaTime;

                // Unity does not allow meshRenderer.materials[0]...
                meshRenderer.materials = mats;
                //Rembran.materials = mats;
                Kleimt.materials = mats;
            }
            if (cuttoff>1)
            {
                meshRenderer.gameObject.SetActive(false);
            }

        }
        if (finalLevel)
        {



            Material[] mats = finalGate.materials;


            if (finalDissolve < 1)
            {
                mats[0].SetFloat("_Cutoff", finalDissolve += .0051f);
                t += Time.deltaTime;

                // Unity does not allow meshRenderer.materials[0]...
                finalGate.materials = mats;
                finalWords.materials = mats;
            }
            if (finalDissolve > 1)
            {
                finalGate.gameObject.SetActive(false);
                finalWords.gameObject.SetActive(false);

            }

        }
        if (unlock)
        {

           

            Material[] mats = door.materials;
            

            if (unlocking < 1)
            {
                mats[0].SetFloat("_Cutoff", unlocking += .0051f);
                t += Time.deltaTime;

                // Unity does not allow meshRenderer.materials[0]...
                door.materials = mats;
                key.materials = mats;
            }
            if (unlocking > 1)
            {
                door.gameObject.SetActive(false);
                key.gameObject.SetActive(false);
               
            }

        }
    }
   
}
