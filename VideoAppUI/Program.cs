using System;
using System.Collections.Generic;
using VideoAppBLL;
using VideoAppBLL.BO;



namespace VideoAppUI
{
    class Program
    {

        static BLLFacade bllfacade = new BLLFacade();
        VideoBO vid = new VideoBO();

        static void Main(string[] args)
        {



            selectOption();



        }

        private static void selectOption()
        {

            string[] videoMenu = {
             "Create a Video",
             "Edit videos",
             "Watch Videos",
             "Delete Videos",
             "Exit Video Menu"};

            var select = showVideoMenu(videoMenu);
            while (select != 5)
            {
                switch (select)
                {
                    case 1:
                        Console.WriteLine("Create a Video");
                        createVideo();
                        break;


                    case 2:
                        Console.WriteLine("Edit videos");
                        editVideo();
                        break;


                    case 3:
                        Console.WriteLine("Watch Videos");
                        listOfVideos();
                        break;


                    case 4:
                        Console.WriteLine("Delete Videos");
                        deleteVideo();
                        break;


                    case 5:
                        Console.WriteLine("Exit Video Menu");

                        break;


                    default:
                        Console.WriteLine("Bye bye");
                        break;
                }
                Console.ReadLine();
                select = showVideoMenu(videoMenu);
            }
            Console.WriteLine("Bye bye");
            Console.ReadLine();


        }

        private static void editVideo()
        {
            var videoFound = getVideoFromList();
            if (videoFound != null)
            {
                Console.WriteLine("Type in new autor name");
                videoFound.Title = Console.ReadLine();
                Console.WriteLine("Type in name of video");
                videoFound.pricePrDay = int.Parse(Console.ReadLine());
                Console.WriteLine("Type in the length of the video");

                bllfacade.VideoAppService.Update(videoFound);
            }
            else
            {
                Console.WriteLine("Video not found");
            }
        }

        private static void deleteVideo()
        {
            var videoFound = getVideoFromList();
            if (videoFound != null)
            {
                bllfacade.VideoAppService.Delete(videoFound.Id);
                Console.WriteLine("Type the id, of the video to delete, strating from 0");


                var response = videoFound == null ?
                    "Video not found" :
                    "Video deleted";
                Console.WriteLine(response);
                Console.ReadLine();
            }
            selectOption();
        }
        private static VideoBO getVideoFromList()
        {
            Console.WriteLine("Type in video Id");
            int Id = int.Parse(Console.ReadLine());

            {
                return bllfacade.VideoAppService.Get(Id);
            }
        }
        private static void listOfVideos()
        {
            foreach (var vid in bllfacade.VideoAppService.GetAll())
            {
                Console.WriteLine($"\n Title:{vid.Title}, Price Pr Day: {vid.pricePrDay}, Id: {vid.Id}");
            }
        }

        private static void createVideo()
        {


            string Title;
            int pricePrDay;

            Console.WriteLine("Type in the title of the movie");
            Title = Console.ReadLine();
            Console.WriteLine("Type in the price of the movie pr.day");
            pricePrDay = int.Parse(Console.ReadLine());



            bllfacade.VideoAppService.Create(new VideoBO()
            {

                Title = Title,
                pricePrDay = pricePrDay


            });

            selectOption();
        }
        private static int showVideoMenu(string[] videoMenu)
        {
            Console.Clear();
            Console.WriteLine("Select a option\n");
            for (int i = 0; i < videoMenu.Length; i++)
            {
                Console.WriteLine((i + 1) + ":" + videoMenu[i]);
            }
            int select;
            while (!int.TryParse(Console.ReadLine(), out select))
            {
                Console.WriteLine("Please select numper between 1-5");
            }
            return select;

        }


    }


}

