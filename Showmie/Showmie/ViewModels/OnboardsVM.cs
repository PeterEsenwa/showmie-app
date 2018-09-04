using System.Collections.Generic;

namespace Showmie
{
    internal class OnboardsVM
    {
        public SingleBoard thirdBoard = new SingleBoard("idea_bulb.png", "Get Inspired to Create", "View the works of many other professionals from around the continient and get inspired");
        public SingleBoard secondBoard = new SingleBoard("tailor_showoff.png", "Showcase your works", "Share content from your gallery or show some of your recent designs for others to see");
        public SingleBoard firstBoard = new SingleBoard("sm_community.png", "A Large Fashion Community", "Connect with lots of fashion lovers and professionals in and outside the country");

        public List<SingleBoard> BoardsList { get; set; } = new List<SingleBoard>();

        public List<SingleBoard> GetBoards()
        {
            BoardsList.Add(firstBoard);
            BoardsList.Add(secondBoard);
            BoardsList.Add(thirdBoard);
            return BoardsList;
        }

        public int NoOfBoards()
        {
            return BoardsList.Count;
        }
    }
}
