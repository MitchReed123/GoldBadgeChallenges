using System;
using System.Collections.Generic;
using System.Text;

namespace Badges
{
    public class BadgeRepository
    {
        private List<Badge> _Badges = new List<Badge>();
        private Dictionary<int, Badge> _BadgeDictionary = new Dictionary<int, Badge>();

        public void AddNewBadges(Badge badge)
        {
            //_Badges.Add(badge);
            _BadgeDictionary.Add(1, badge);
        }

        public Badge GetByID(int id)
        {
            foreach (Badge item in _Badges)
            {
                if (item.BadgeID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public bool RemoveDoorsFromBadge(int id)
        {
            Badge content = GetByID(id);

            if (content.DoorNames == null)
            {
                return false;
            }

            int initialCount = _BadgeDictionary.Count;
            _BadgeDictionary.Remove(1, out content);

            if (initialCount > _BadgeDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateDoorsOnBadge(Badge badge, int ID)
        {
            Badge content = GetByID(ID);
            if (content.DoorNames != null)
            {
                int badgeIndex = _Badges.IndexOf(content);
                _Badges[badgeIndex] = badge;
                return true;
            }
            return false;
        }

        public List<Badge> GetBadges()
        {
            return _Badges;
        }
    }
}
