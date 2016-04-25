using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Server
{
    public enum ClientOpcode
    {
        LoginInfo = 3,
        Walking = 6,
        Pickup = 7,
        Look = 10,
        Logout = 11,
        Speak = 14,
        UseSpell = 15,
        Redirected = 16,
        FaceDirection = 17,
        OpenUserList = 24,
        Whisper = 25,
        UseItem = 28,
        DisplayProfile = 45,
        Group = 46,
        ToggleGroup = 47,
        Refresh = 56,
        GossipMenu = 57,
        PopupSelect = 58,
        Boards = 59,
        SendMail = 59,
        UseSkill = 62,
        ClickCharacter = 67,
        Unequip = 68,
        ItemTransfer = 74,
        SpellLines = 77,
        ChangeStatus = 121,
    }
}
