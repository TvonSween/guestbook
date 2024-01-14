using GuestbookMiniProject;

GuestLogic.Welcome();

(List<string> guests, int guestTotal) attendees = GuestLogic.GetGuestList();

GuestLogic.DisplayGuestList(attendees.guests, attendees.guestTotal);
