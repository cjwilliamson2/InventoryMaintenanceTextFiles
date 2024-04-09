namespace InventoryMaintenance
{
	public static class InventoryDB
	{
		private const string Path = @"..\..\..\InventoryItems.txt";

        public static List<InventoryItem> GetItems()
		{
            // create the list
            List<InventoryItem> items = new();

            //TODO: Add code here to read the text file into the List<InventoryItem> object.

            // Create a FileStream to open our file for reading
            // Create a Streamreder to read from file

            try
            {
                FileStream inFile = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read);
                using StreamReader textIn = new StreamReader(inFile);

                while (textIn.Peek() != -1)
                {
                    try
                    {
                        string line = textIn.ReadLine()!;
                        string[] itemProperties = line.Split("|");

                        //Create an InventoryItem

                        InventoryItem item = new InventoryItem(
                            Convert.ToInt32(itemProperties[0]),
                            itemProperties[1],
                            Convert.ToDecimal(itemProperties[2])
                        );

                        // Add new InventoryItem to items list
                        items.Add(item);
                    } catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.ToString());
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }

            return items;
		}

		public static void SaveItems(List<InventoryItem> items)
		{
            // Add code here to write the List<InventoryItems> object to a text file.
        }
    }
}