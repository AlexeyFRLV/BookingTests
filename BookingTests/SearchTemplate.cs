using System.Collections.Generic;

namespace BookingTests
{
    class SearchTemplate
    {
        public string City { get; set; }
        public string CheckInDate { get; }
        public string EvictionDate { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Room { get; set; }
        public List<string> templateParam;

        public SearchTemplate()
        {
            templateParam = new List<string>();
            City = "Минск";
            CheckInDate = "понедельник, 3 мая 2021";
            EvictionDate = "среда, 5 мая 2021";
            Adult = 2;
            Child = 1;
            Room = 1;
        }


        public List<string> GetTemplateParam()
        {
            templateParam.Add(City);
            templateParam.Add(CheckInDate);
            templateParam.Add(EvictionDate);
            templateParam.Add(Adult.ToString());
            templateParam.Add(Child.ToString());
            templateParam.Add(Room.ToString());

            return templateParam;
        }
    }


}
