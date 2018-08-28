using System.Collections.Generic;

namespace Showmie
{
    internal class OnboardsVM
    {
        public SingleBoard thirdBoard = new SingleBoard("idea_bulb.png", "View the works of many other professionals from around the continient and get inspired", "Get Inspired to Create");
        public SingleBoard secondBoard = new SingleBoard("tailor_showoff.png", "Share content from your gallery our show some of your recent designs", "Showcase your works");
        public SingleBoard firstBoard = new SingleBoard("sm_community", "Connect with lots of fashion lovers and professionals in and outside the country", "A Thriving Fashion Community");

        public List<SingleBoard> BoardsList { get; set; } = new List<SingleBoard>();

        public List<SingleBoard> GetBoards()
        {
            BoardsList.Add(firstBoard);
            BoardsList.Add(secondBoard);
            BoardsList.Add(thirdBoard);
            return BoardsList;
        }
    }
}
