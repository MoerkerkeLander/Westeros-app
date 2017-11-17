﻿using ASOIAF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASOIAF.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterPage : ContentPage
	{
		private List<Character> Characters { get; set; }

		public CharacterPage()
		{
			InitializeComponent();
			LoadCharacters();

			lvwCharacters.ItemSelected += LvwCharacters_ItemSelected;
		}

		private void LvwCharacters_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (lvwCharacters.SelectedItem != null)
			{
				Character selectedCharacter = lvwCharacters.SelectedItem as Character;
				Navigation.PushAsync(new CharacterDetail(selectedCharacter));

				lvwCharacters.SelectedItem = null;
			}
		}

		private async void LoadCharacters()
		{
			Characters = await WesterosManager.GetCharactersAsync();
			Characters = Characters.FindAll(c => c.Name != "");
			lvwCharacters.ItemsSource = Characters;
		}
	}
}