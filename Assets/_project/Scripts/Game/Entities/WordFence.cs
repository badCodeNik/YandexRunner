using _project.Scripts.Services;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.Entities
{
    [RequireComponent(typeof(Collider))]
    public class WordFence : MonoBehaviour
    {
        [SerializeField] private Collider collider;
        public bool IsRight { get; private set; }
        private Signal _signal;


        public void Initialize()
        {
            _signal = AllServices.Container.Single<Signal>();
        }
        private void OnEnable()
        {
            collider ??= GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
}