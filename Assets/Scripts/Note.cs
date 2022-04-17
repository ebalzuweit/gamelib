using UnityEngine;

namespace com.ebalzuweit.gamelib
{
    public class Note : MonoBehaviour
    {
        [SerializeField, TextArea(minLines: 1, maxLines: 48)]
        private string _contents;
    }
}
