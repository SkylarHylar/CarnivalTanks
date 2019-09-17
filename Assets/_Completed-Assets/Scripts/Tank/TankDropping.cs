using UnityEngine;
using UnityEngine.UI;

namespace Complete
{
    public class TankDropping : MonoBehaviour
    {
        public int m_PlayerNumber = 1;              // Used to identify the different players.
        public GameObject m_Mine;                    // Prefab of the shell.
        public Transform m_MineTransform;           // A child of the tank where the shells are spawned.
        public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
        public AudioClip m_FireClip;                // Audio that plays when each shot is fired.


        private string m_MineButton;                // The input axis that is used for launching shells.
        private float m_Time = 3f;
        public float m_Cooldown;                    // The cooldown on the placement of mines.


        private void OnEnable()
        {
            
        }


        private void Start()
        {
            // The fire axis is based on the player number.
            m_MineButton = "Mine" + m_PlayerNumber;


        }


        private void Update()
        {
            if ((Input.GetButtonDown(m_MineButton)) && (m_Cooldown <=0))
            {
                Fire();
                m_Cooldown = m_Time;
            }
            if(m_Cooldown > 0)
            {
                m_Cooldown -= Time.deltaTime;
                if (m_Cooldown < 0) m_Cooldown = 0;
            }
        }


        private void Fire()
        {

            // Create an instance of the shell and store a reference to it's rigidbody.
            GameObject Mine = Instantiate(m_Mine, m_MineTransform.position, m_MineTransform.rotation);

            Mine.GetComponent<Complete.MineExplosion>().creator = gameObject;
            Mine.GetComponent<Complete.MineExplosion>().color = GameObject.Find("GameManager").GetComponent<Complete.GameManager>().m_Tanks[m_PlayerNumber - 1].m_PlayerColor;
            // Change the clip to the firing clip and play it.
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();

        }
    }
}