using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Projet
{
    [CreateAssetMenu(
        fileName = "NewImage",
        menuName = "image")]

    public class ImageClass : ScriptableObject
    {
        // je voulais essayer de changer d'image...
        [SerializeField] private Image _image;


        public Image image => _image;
    }
}
