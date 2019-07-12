using System;
using System.Collections.Generic;
using System.Text;
using GameLogicInterfaces.Models;

namespace GameLogicInterfaces.Datasource
{
    public interface IGameData
    {
        List<Character> GetActors();
        List<Domain> GetDomains();
        List<string> AssetsForCharacter(string characterId);
        List<Asset> Assets();
        List<Endeavour> Endeavours();
        List<string> EndeavoursForCharacter(string characterId);
    }
}
