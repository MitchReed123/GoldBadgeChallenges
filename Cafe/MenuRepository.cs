using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe
{
    public class MenuRepository
    {
        //where the logic for the add/delete/display methods will go
        private List<Menu> _menu = new List<Menu>();

        public void AddContentToMenu(Menu item)
        {
            _menu.Add(item);
        }

        public void DeleteContentFromMenu(Menu item)
        {
            _menu.Remove(item);
        }

        public Menu GetByName(string name)
        {
            foreach (Menu item in _menu)
            {
                if(item.MealName.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public bool RemoveContentFromList(string title)
        {
            Menu content = GetByName(title);

            if(content == null)
            {
                return false;
            }

            int initialCount = _menu.Count;
            _menu.Remove(content);
            
            if(initialCount > _menu.Count)
            {
                return true;
            } else
            {
                return false;
            }
        }


        public List<Menu> GetMenu()
        {
            return _menu;
        }

        public bool DeleteItems(Menu item)
        {
            return _menu.Remove(item);
        }
    }
}
