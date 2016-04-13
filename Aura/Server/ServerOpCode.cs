using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Server
{
    public enum ServerOpcode
    {
        Redirect = 3,
        Location = 4,
        PlayerID = 5,
        DisplayNpc = 7,
        Statistics = 8,
        SystemMessage = 10,
        MoveClient = 11,
        MoveCharacter = 12,
        Chat = 13,
        RemoveCharacter = 14,
        AddItem = 15,
        RemoveItem = 16,
        CharacterTurn = 17,
        HpBar = 19,
        MapInfo = 21,
        AddSpell = 23,
        RemoveSpell = 24,
        Sounds = 25,
        BodyAnimation = 26,
        NewMap = 31,
        SpellAnimation = 41,
        AddSkill = 44,
        RemoveSkill = 45,
        DisplayWorldMap = 46,
        DialogueResponse = 47,
        PopUpResponse = 48,
        BulletinBoards = 49,
        Wall = 50,
        DisplayPlayer = 51,
        Legend = 52,
        CountryList = 54,
        Appendage = 55,
        RemoveAppendage = 56,
        Profile = 57,
        SpellBar = 58,
        PingA = 59,
        Cooldown = 63,
        ExchangeWindow = 66,
        CancelCasting = 72,
        UnC = 76,
        WorldMapResponse = 103,
        PingB = 104,
        Metafile = 111,
    }
}
