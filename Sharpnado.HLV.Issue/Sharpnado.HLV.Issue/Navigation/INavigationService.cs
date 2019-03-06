using Sharpnado.HLV.Issue.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sharpnado.HLV.Issue.Navigation
{
    public interface INavigationService
    {
        Task NavigateTo(PageType pageType);
        Task NavigateTo<T>(PageType pageType, T paramter);
        Task NavigateTo<T1, T2>(PageType pageType, T1 p1, T2 p2);
        Task NavigateTo<T1, T2, T3>(PageType pageType, T1 p1, T2 p2, T3 p3);
        Task NavigateTo<T1, T2, T3, T4>(PageType pageType, T1 p1, T2 p2, T3 p3, T4 p4);
        Task Back();
        Task Back(int steps);
        Task BackTo(PageType pageType);
    }
}
