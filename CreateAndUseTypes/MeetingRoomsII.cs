using System;
using System.Collections.Generic;
using System.Text;

namespace CreateAndUseTypes
{
    //P15: Find the minimum number of conference rooms required.
    //Source: https://leetcode.com
    class MeetingRoomsII
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            if(intervals == null || intervals.Length == 0)
            {
                return 0; 
            }
            int numRooms = 0;

            var rooms = new Dictionary<int, List<int[]>>(); 

            foreach(var meeting in intervals)
            {
                if (IsAvailableRoomAndAdd(rooms, meeting))
                    continue;

                var meetings = new List<int[]>();
                meetings.Add(meeting);
                rooms.TryAdd(numRooms, meetings);
                numRooms++;
            }

            return numRooms; 
        }

        private bool IsAvailableRoomAndAdd(Dictionary<int, List<int[]>> rooms, int[] meeting)
        {
            foreach(var room in rooms)
            {
                if(isRoomAvailable(room, meeting))
                {
                    int key = room.Key;
                    var meetings = room.Value;
                    meetings.Add(meeting);
                    rooms[key] = meetings;
                    
                    return true;
                }
            }

            return false; 
        }

        private bool isRoomAvailable(KeyValuePair<int, List<int[]>> room, int[] meeting)
        {
            bool result = true;
            foreach(var scheduledMeeting in room.Value)
            {
                if(!isAvailable(scheduledMeeting, meeting))
                {
                    result = false;
                }
            }
            return result; 
        }

        private bool isAvailable(int[] scheduledMeeting, int[] meeting)
        {
            if( ( (scheduledMeeting[0] < meeting[0]) && (scheduledMeeting[1] <= meeting[0]) ) ||
                ( (meeting[0] < scheduledMeeting[0]) && (meeting[1] <= scheduledMeeting[0]) ) )
            {
                return true;
            }
            return false;
        }
    }
}
