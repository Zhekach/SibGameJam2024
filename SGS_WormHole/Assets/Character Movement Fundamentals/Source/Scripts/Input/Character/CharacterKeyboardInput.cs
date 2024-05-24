using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
	//This character movement input class is an example of how to get input from a keyboard to control the character;
    public class CharacterKeyboardInput : CharacterInput
    {
		public string _horizontalInputAxis = "Horizontal";
		public string _verticalInputAxis = "Vertical";
		public KeyCode _jumpKey = KeyCode.Space;
		public KeyCode _createPlatformKey = KeyCode.F;

		//If this is enabled, Unity's internal input smoothing is bypassed;
		public bool useRawInput = true;

        public override float GetHorizontalMovementInput()
		{
			if(useRawInput)
				return Input.GetAxisRaw(_horizontalInputAxis);
			else
				return Input.GetAxis(_horizontalInputAxis);
		}

		public override float GetVerticalMovementInput()
		{
			if(useRawInput)
				return Input.GetAxisRaw(_verticalInputAxis);
			else
				return Input.GetAxis(_verticalInputAxis);
		}

		public override bool IsJumpKeyPressed()
		{
			return Input.GetKey(_jumpKey);
		}

		public override bool IsCreatePlatformKeyPressed()
		{
			return Input.GetKey(_createPlatformKey);
		}

		public override bool IsCreatePlatformKeyUp()
		{
			return Input.GetKeyUp(_createPlatformKey);
		}
    }
}