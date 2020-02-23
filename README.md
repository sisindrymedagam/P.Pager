# <p align="center"> <img src="https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/icon.png" width="25" height="25" title="Github Logo"> P.Pager</p>

## What is this?
P.Pager is Lightweight package for easily paging through any IEnumerable/IQueryable, chop it up into "pages", and grab a specific "page" by an index. It supports Web projects, Winforms, WPF, Window Phone, Silverlight and other .NET projects. It is default configured to **> Bootstrap 3.3.1**.

## How do I use it?
### Installation
#### .Net Framework ( > 4.5.2)
Install [P.Pager.Mvc](https://www.nuget.org/packages/P.Pager.Mvc/) via [NuGet](http://nuget.org). This will install [P.Pager](https://www.nuget.org/packages/P.Pager/) automatically.
```
Install-Package P.Pager.Mvc -Version 3.0.0
```
#### .Net Core (.NET Standard 2.0)
Install [P.Pager.Mvc.Core](https://www.nuget.org/packages/P.Pager.Mvc.Core/) via [NuGet](http://nuget.org). This will install [P.Pager](https://www.nuget.org/packages/P.Pager/) automatically.
```
Install-Package P.Pager.Mvc.Core -Version 1.4.0
```

#### .Net Core 3 and above (.NET Standard 2.1)
Install [P.Pager.Mvc.Core](https://www.nuget.org/packages/P.Pager.Mvc.Core/) via [NuGet](http://nuget.org). This will install [P.Pager](https://www.nuget.org/packages/P.Pager/) automatically.
```
Install-Package P.Pager.Mvc.Core -Version 3.0.0
```

### After that
1. In your controller code, call **ToPagerList** off of your IEnumerable/IQueryable passing in the page size.
```csharp

public class HomeController : Controller
{
    readonly DemoData _data;
    public HomeController()
    {
        _data = new DemoData();
    }

    public ActionResult Index(int page = 1, int pageSize = 10)
    {
        var pager = _data.GetMembers().ToPagerList(page, pageSize);
        // will only contain 10 members max because of the pageSize.
        return View(pager);
    }
}       
```

2. Pass the result of **ToPagerList** to your view where you can enumerate over it - its still an IEnumerable, but only contains a child of the original data.

3. Call **Html.Pager**, passing in the instance of the Pager and a function that will generate URLs for each page to see a paging control.

```csharp
//Default Pager options
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }))
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/1.default.PNG)

## PagerOptions
Default options for rendering pagination.
#### Properties
|Option|Type|Summary|Default|
|-----------|-----------|-------|---|
|DisplayFirstPage|[PagerDisplayMode](#pagerdisplaymode)|If set to Always, render a hyperlink to the first page in the list. If set to IfNeeded, render the hyperlink only when the first page isn't visible in the paging control.|IfNeeded|
|DisplayLastPage|[PagerDisplayMode](#pagerdisplaymode)|If set to Always, render a hyperlink to the last page in the list. If set to IfNeeded, render the hyperlink only when the last page isn't visible in the paging control.|IfNeeded|
|DisplayPreviousPage|[PagerDisplayMode](#pagerdisplaymode)|If set to Always, render a hyperlink to the previous page of the list. If set to IfNeeded, render the hyperlink only when there is a previous page in the list.|IfNeeded|
|DisplayNextPage|[PagerDisplayMode](#pagerdisplaymode)|If set to Always, render a hyperlink to the next page of the list. If set to IfNeeded, render the hyperlink only when there is a next page in the list.|IfNeeded|
|PagesToDisplay|int?|How many page numbers to display in pagination, by default it is 5.|5|
|HasIndividualPages|bool|Display pages numbers. Refer [PagesToDisplay]()|true|
|TextToIndividualPages|string|A formatted text to show to show inside the hyperlink. Use {0} to refer page number, by default it is set to {0}|{0}|
|TextForDelimiter|string|This will appear between each page number. If null or white space, no delimeter will display.|null|
|HasEllipses|bool|Adds an ellipe when all page numbers are not displaying, by default it is true.|true|
|EllipsesFormat|string|A formatted text shows when all pages are not displaying, by default it is &#8230;|&#8230;|
|TextToFirstPage|string|A formatted text to show for firstpage link, by default it is set to &lt;&lt;.|&lt;&lt;|
|TextToPreviousPage|string|A formatted text to show for previous page link, by default it is set to &lt;.|&lt;|
|TextToNextPage|string|A formatted text to show for next page link, by default it is set to &gt;.|&gt;|
|TextToLastPage|string|A formatted text to show for last page link, by default it is set to &gt;&gt;.|&gt;&gt;|
|ClassToPagerContainer|string|Css class to append to &lt;div&gt; element in the paging content, by default it is set to pager container.|container|
|ClassToUl|string|Css class to append to &lt;ul&gt; element in the paging content, by default it is set to pagination.|pagination|
|ClassToLi|string|Css class to append to &lt;li&gt; element in the paging content, by default it is set to page-item.|page-item|
|PageClass|string|Css class to append to &lt;a&gt;/&lt;span&gt; element in the paging content, by default it is set to page-link.|page-link|
|ClassToActiveLi|string|Css class to append to &lt;li&gt; element if active in the paging content, by default it is set to active.|active|
|HasPagerText|bool|Displaying current page number and total number of pages in pager, by default it is set to false.|false|
|PagerTextFormat|string|Text format will display if HasPagerText is true. Use {0} to refer the current page and {0} to refer total number of pages, by default it is set to Page {0} of {1}.|Page {0} of {1}.|
|HasEntriesText|bool|Displaying start item, last item and total entries in pager, by default it is set to false.|false|
|EntriesTextFormat|string|Text format will display if HasEntriesText is true. {0} refers first entry on page, {1} refers last item on page and {2} refers total number of entries, by default it is set to Showing {0} to {1} of {2} entries.|Showing {0} to {1} of {2} entries.|

### PagerDisplayMode
A tri-state enum that controls the visibility of portions of the PagerList paging control.
```csharp
public enum PagerDisplayMode
```
|Fields|Description|
|---|----|
|Always|Always render.|
|Never|Never render.|
|IfNeeded|Only render when there is data that makes sense to show (context sensitive).|

### How to use PagerOptions?
1. Shows custom page numbers, let say 10 pages.
```csharp
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), new PagerOptions { PagesToDisplay = 10 })
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/7.custompagenumbers.PNG)

2. With Custom Page Text.
```csharp
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), new PagerOptions { TextToIndividualPages = "Page-{0}" })
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/8.CustomPageText.PNG)

3. Custom Wording. (<i>Can use for translation also.</i>)
```csharp
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), new PagerOptions { TextToPreviousPage = "Previous Page", TextToNextPage = "Next Page", TextToFirstPage = "First Page", TextToLastPage = "Last Page" })
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/9.CustomWording.PNG)

4. Custom options.
```csharp
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), new PagerOptions { TextToPreviousPage = "last-page", TextToNextPage = "next-page", TextToFirstPage = "first-page", TextToLastPage = "last-page", ClassToUl = "list-inline", ClassToLi = "list-inline-item", PageClass = "nopageclass", ClassToActiveLi = "niloclass", TextForDelimiter = " | " })
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/10.CustomOptions.PNG)

5. Custom Icon Options (Fontawesome)
```csharp
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), new PagerOptions { TextToPreviousPage = "<i class='fas fa-step-backward'></i>", TextToNextPage = "<i class='fas fa-step-forward'></i>", TextToFirstPage = "<i class='fas fa-fast-backward'></i>", TextToLastPage = "<i class='fas fa-fast-forward'></i>" })
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/11.Using%20Icons.PNG)

## PrePagerOptions
1. Minimal Pager
```csharp
//Shows only the Previous and Next links.
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), PrePagerOptions.Minimal)
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/2.%20minimal.PNG)

2. Minimal Pager with Pager Text (Page Count Text)
```csharp
//Shows Previous and Next links along with current page number and total number of pages in pager.
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), PrePagerOptions.MinimalWithPagerText)
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/3.minimalpagecount.PNG)

3. Minimal Pager with entries text (Item Count Text)
```csharp
//Shows Previous and Next links along with index of start and last item and total entries in pager.
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), PrePagerOptions.MinimalWithEntriesText)
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/4.minimalwithentries.PNG)

4. Classic Pager <small>(always shows Previous/Next links, but sometimes they are disabled)</small>
```csharp
//Shows Previous and Next page always with default, 5 pages.
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), PrePagerOptions.ClassicPager)
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/5.classic.PNG)

6. Classic Pager with First and Last<small>(Classic Pager with First and Last links, but sometimes they are disabled)</small>
```csharp
//Shows Last, First, Previous and Next page always with default, 5 pages. 
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), PrePagerOptions.ClassicPagerWithFirstAndLastPages)
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/6.classiclastfirst.PNG)

## License
Licensed under the [MIT License](https://github.com/PuffinWeb/P.Pager/blob/master/LICENSE).
