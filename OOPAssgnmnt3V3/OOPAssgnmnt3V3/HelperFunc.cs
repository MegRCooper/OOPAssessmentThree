using OOPAssgnmnt3V3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAssgnmnt3V3
{
    public static class HelperFunc
    {
        public static Change ReadUnchanged(string[] file, int currentFilePos)
        {
            // The words action is set to be unchanged and the nessary extra attributes are added to the list as well
            return (new Change { Word = file[currentFilePos], Pos = currentFilePos, Action = Actions.Unchanged, WordColour = ConsoleColor.White });
        }

        internal static List<Change> SetLineNum(List<Change> changesInFiles)
        {
            int lineNum = 1;
            foreach (Change changesInFile in changesInFiles)
            {
                if (changesInFile.Word == string.Empty)
                {
                    lineNum++;
                }
                changesInFile.LineNum = lineNum;
            }
            return (changesInFiles);
        }

        //function to read ahead in the file to search for a specific character
        public static List<Change> ReadAhead(string searchString, string[] file, int currentFilePos, Actions action, ConsoleColor colour)
        {
            //new list is created to hold possibles
            List<Change> posChanges = new List<Change>();

            //when the end of the file is reached
            if (file.Length == currentFilePos)
            {
                //changes found get returned
                return posChanges;
            }
            //loops through the file from the specified position until the end of the file is met
            for (int i = currentFilePos; i < file.Length; i++)
            {
                //if the searchstring is found
                if (searchString == file[i])
                {
                    break;
                }
                //values added to the possible changes list
                posChanges.Add(new Change { Word = file[i], Pos = i, Action = action, WordColour = colour });
            }
            return (posChanges);
        }

        //bool function checking if the end of the file has been met
        public static bool EndOfFile(string[] file, int currentFilePos)
        {
            return (file.Length <= currentFilePos);
        }

        public static bool EndOfFile(List<Change> file, int currentFilePos)
        {
            return file.Count <= currentFilePos;
        }

        //function to return any values left on the end of a file
        public static List<Change> ReadToEnd(string[] file, int currentFilePos, Actions action, ConsoleColor colour)
        {
            //new list made to hold changes
            List<Change> posChanges = new List<Change>();

            //check for the end of file.
            if (file.Length == currentFilePos)
            {
                //changes returned
                return posChanges;
            }
            //loops through all values in the file left after the given position
            for (int i = currentFilePos; i < file.Length; i++)
            {
                //values added to the change list
                posChanges.Add(new Change { Word = file[i], Pos = i, Action = action, WordColour = colour });
            }
            //change list returned
            return (posChanges);
        }

        private static int offsetCount(List<Change> posAdd, List<Change> posRem, int offset)
        {
            bool firstFound = false;
            bool nextDiff = false;
            int matchCount = 0;
            int addPos = 0;
            int removePos = 0;

            if (posAdd.Count < posRem.Count)
            {
                removePos = offset;
            }
            else
            {
                addPos = offset;
            }

            while (!nextDiff && !EndOfFile(posAdd, addPos) && !EndOfFile(posRem, removePos))
            {
                if (posAdd[addPos].Word == posRem[removePos].Word)
                {
                    firstFound = true;
                    matchCount++;
                }
                if (firstFound && posAdd[addPos].Word != posRem[removePos].Word)
                {
                    nextDiff = true;
                }
                addPos++;
                removePos++;
            }
            return matchCount;
        }

        public static List<Change> MergeReadAhead(List<Change> possibleAdditions, List<Change> possibleRemovals)
        {
            List<Change> shorterList;
            List<Change> longerList;
            if (possibleAdditions.Count < possibleRemovals.Count)
            {
                shorterList = possibleAdditions;
                longerList = possibleRemovals;
            }
            else
            {
                shorterList = possibleRemovals;
                longerList = possibleAdditions;
            }

            Dictionary<int, int> matchCount = new Dictionary<int, int>();

            for (int i = 0; i < longerList.Count - shorterList.Count; i++)
            {
                matchCount.Add(i, offsetCount(shorterList, longerList, i));
            }

            int offset = matchCount.FirstOrDefault(x => x.Value == matchCount.Values.Max()).Key;
            List<Change> mergedChanges = new List<Change>();


            for (int i = 0; i < offset; i++)
            {
                mergedChanges.Add(longerList[i]);
            }

            for (int i = 0; i < shorterList.Count; i++)
            {
                if (shorterList[i].Word == longerList[i + offset].Word)
                {
                    break;
                }

                mergedChanges.Add(longerList[i + offset]);
                mergedChanges.Add(shorterList[i]);
            }
            return mergedChanges;
        }
    }
}
