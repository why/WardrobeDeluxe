using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sulakore.Communication;
using Tangine;
using Sulakore.Modules;

namespace TeleportSS
{
    [Module("Wardrobe Deluxe", "To the moon and further!")]
    [GitHub("notmika", "WardrobeDeluxe")]
    [Author("Mika", HabboName = "96", Hotel = Sulakore.Habbo.HHotel.Nl, ResourceName = "Follow on Twitter", ResourceUrl = "https://twitter.com/Metoniem")]
    public partial class Form1 : ExtensionForm
    {
        public ushort PlacePet { get; set; }
        public ushort Walk { get; set; }
        public ushort MovePet { get; set; }
        public ushort MountPet { get; set; }
        public int PetId { get; set; }
        public Random Randomizer = new Random();

        public Form1()
        {
            InitializeComponent();

            PlacePet = Game.GetMessageHeaders("d7eadc2163756ff7b1dfb130f493d7a4")[0];
            Walk = Game.GetMessageHeaders("5dec6a7881d4a598d5b15d0e743bcdcb")[0];
            MovePet = Game.GetMessageHeaders("68563ba310531af2a2c256663e0d2524")[0];
            MountPet = Game.GetMessageHeaders("ea8690d440d59e281e545eac19306aa2")[0];

            Triggers.OutAttach(PlacePet, PetPlaced);
        }

        private void PetPlaced(DataInterceptedEventArgs obj)
        {
            PetId = obj.Packet.ReadInteger();

            obj.Packet.ReadInteger();
            obj.Packet.ReadInteger();

            Triggers.OutAttach(MountPet, PetMounted);
            Triggers.OutDetach(obj.Packet.Header);
            InfoLbl.Text = "Please mount (ride) the horse..";
        }

        private void PetMounted(DataInterceptedEventArgs obj)
        {
            int id = obj.Packet.ReadInteger();
            if (id == PetId && obj.Packet.ReadBoolean())
            {
                Triggers.OutAttach(Walk, Walked);
                Triggers.OutDetach(obj.Packet.Header);
                InfoLbl.Text = "Click anywhere to teleport!";
            }
        }

        private async void Walked(DataInterceptedEventArgs obj)
        {
            int x = obj.Packet.ReadInteger();
            int y = obj.Packet.ReadInteger();

            await Connection.SendToServerAsync(MovePet, PetId, x, y, Randomizer.Next(0, 8));
            obj.IsBlocked = true;
        }
    }
}
