using DB.PALIY.AUC.Model;
using DB.PALIY.AUC.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.PALIY.AUC.ModelView
{
    class ParticipantPageViewModel : BaseClass
    {
        AuctionDb1Context db = new AuctionDb1Context();
        private ObservableCollection<Participant> participantList;
        public ObservableCollection<Participant> ParticipantList
        {
            get { return participantList; }
            set
            {
                participantList = value;
                OnPropertyChanged(nameof(ParticipantList));
            }
        }

        public ParticipantPage window;

        private Participant? selectParticipant;
        public Participant? SelectParticipant
        {
            get { return selectParticipant; }
            set
            {
                selectParticipant = value;
                OnPropertyChanged(nameof(SelectParticipant));
            }

        }
        public ParticipantPageViewModel()
        {
            db.Participants.Load();
            ParticipantList = db.Participants.Local.ToObservableCollection();
        }
        //private RelayCommand? addCommand;
        //public RelayCommand AddCommand
        //{
        //    get
        //    {
        //        return addCommand ??
        //            (addCommand = new RelayCommand(obj =>
        //            {
        //                AddEditItem window = new AddEditItem(new Item());
        //                if (window.ShowDialog() == true)
        //                {
        //                    Item item = window.Item;
        //                    db.Items.Local.Add(item);
        //                    db.SaveChanges();
        //                }
        //            }));
        //    }
        //}

        private Participant selectedParticipant;
        public Participant SelectedParticipant
        {
            get { return selectedParticipant; }
            set
            {
                selectedParticipant = value;
                OnPropertyChanged(nameof(SelectedParticipant));

            }
        }
        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand(obj =>

                    {
                        Participant? participant = obj as Participant;
                        if (participant != null) return;
                        {
                            participant.Name = window.Participant.Name;
                            participant.ContactInformation = window.Participant.ContactInformation;
                            participant.Type = window.Participant.Type;
                            participant.Login = window.Participant.Login;
                            participant.Password = window.Participant.Password;
                        }
                    }));
            }
        }


        //    RelayCommand? deleteCommand;
        //    public RelayCommand DeleteCommand
        //    {
        //        get
        //        {
        //            return deleteCommand ??
        //                (deleteCommand = new RelayCommand(selectedItem =>
        //                {
        //                    // получаем выделенный объект
        //                    Item? item = selectItem as Item;
        //                    if (item == null) return;
        //                    db.Items.Remove(item);
        //                    db.SaveChanges();
        //                }));
        //        }
        //    }
    }
}