using UnityEngine;

enum Type
{
	Number, Enter, Clear
}

public class Button : MonoBehaviour
{
	[SerializeField] private ElectricLock _electricLock;
	[SerializeField] private Type _typeButton;
    [SerializeField] private int _number = 0;



	private void OnMouseDown()
	{
		switch (_typeButton)
		{
			case Type.Enter:
				_electricLock.CheckPassword();
				break;

			case Type.Clear:
				_electricLock.ClearText();
				break;

			case Type.Number:
				_electricLock.AddNumber(_number);
				break;
		}
	}
}
