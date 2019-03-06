using Sharpnado.HLV.Issue.Models;
using Sharpnado.HLV.Issue.ViewModels;
using Sharpnado.HLV.Issue.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sharpnado.HLV.Issue.Navigation
{
    public class NavigationService : INavigationService
    {
        private MainPage _mainPage;
        readonly Dictionary<PageType, Func<object, object, object, object, NavigationPage>> MenuPages = new Dictionary<PageType, Func<object, object, object, object, NavigationPage>>();
        readonly Stack<KeyValuePair<PageType, NavigationPage>> History = new Stack<KeyValuePair<PageType, NavigationPage>>();

        public NavigationService()
        {
            _mainPage = (MainPage)App.Current.MainPage;
            RegisterPages();
        }

        public async Task NavigateTo(PageType pageType)
        {
            if (!MenuPages.ContainsKey(pageType)) return;
            await ProcessNavigation(pageType, () => MenuPages[pageType](null, null, null, null));
        }

        public async Task NavigateTo<T>(PageType pageType, T paramter)
        {
            if (!MenuPages.ContainsKey(pageType)) return;
            await ProcessNavigation(pageType, () => MenuPages[pageType](paramter, null, null, null));
        }

        public async Task NavigateTo<T1, T2>(PageType pageType, T1 p1, T2 p2)
        {
            if (!MenuPages.ContainsKey(pageType)) return;
            await ProcessNavigation(pageType, () => MenuPages[pageType](p1, p2, null, null));
        }

        public async Task NavigateTo<T1, T2, T3>(PageType pageType, T1 p1, T2 p2, T3 p3)
        {
            if (!MenuPages.ContainsKey(pageType)) return;
            await ProcessNavigation(pageType, () => MenuPages[pageType](p1, p2, p3, null));
        }

        public async Task NavigateTo<T1, T2, T3, T4>(PageType pageType, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            if (!MenuPages.ContainsKey(pageType)) return;
            await ProcessNavigation(pageType, () => MenuPages[pageType](p1, p2, p3, p4));
        }

        public async Task Back()
        {
            _mainPage = (MainPage)App.Current.MainPage;
            var page = History.Pop();
            await _mainPage.NavigateTo(page.Value);
        }

        public async Task Back(int steps)
        {
            _mainPage = (MainPage)App.Current.MainPage;
            NavigationPage page = null;
            for (int i = 0; i < steps; i++)
            {
                page = History.Pop().Value;
            }
            if (page != null)
            {
                await _mainPage.NavigateTo(page);
            }
        }

        public async Task BackTo(PageType pageType)
        {
            _mainPage = (MainPage)App.Current.MainPage;
            KeyValuePair<PageType, NavigationPage> page = new KeyValuePair<PageType, NavigationPage>();
            do
            {
                page = History.Pop();
            } while (page.Key != pageType);
            await _mainPage.NavigateTo(page.Value);
        }

        private void RegisterPages()
        {
            MenuPages.Add(PageType.Items, (p1, p2, p3, p4) => new NavigationPage(new ItemsPage()));
            MenuPages.Add(PageType.Item, (p1, p2, p3, p4) => new NavigationPage(new ItemDetailPage((ItemDetailViewModel)p1)));
            MenuPages.Add(PageType.About, (p1, p2, p3, p4) => new NavigationPage(new AboutPage()));
        }

        private async Task ProcessNavigation(PageType pageType, Func<NavigationPage> func)
        {
            _mainPage = (MainPage)App.Current.MainPage;
            History.Push(new KeyValuePair<PageType, NavigationPage>(_mainPage.CurrentPageType, (NavigationPage)_mainPage.Detail));
            var page = func();
            _mainPage.CurrentPageType = pageType;
            await _mainPage.NavigateTo(page);
        }
    }
}
