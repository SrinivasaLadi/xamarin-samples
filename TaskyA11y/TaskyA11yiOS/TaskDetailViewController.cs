// This file has been autogenerated from parsing an Objective-C header file added in Xcode.

using System;
using Foundation;
using UIKit;

namespace TaskyA11y
{
	public partial class TaskDetailViewController : UITableViewController
	{
		TodoItem currentTask {get;set;}
		public RootViewController Delegate {get;set;}

		public TaskDetailViewController (IntPtr handle) : base (handle)
		{

		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SaveButton.TouchUpInside += (sender, e) => {
				currentTask.Name = TitleText.Text;
				currentTask.Notes = NotesText.Text;
				currentTask.Done = DoneSwitch.On;
				Delegate.SaveTask(currentTask);

				// TODO: review use of UIAccessibility.PostNotification
				UIAccessibility.PostNotification (UIAccessibilityPostNotification.Announcement,new NSString(@"Item was saved"));
			};

			DeleteButton.TouchUpInside += (sender, e) => {
				Delegate.DeleteTask(currentTask);

				// TODO: review use of UIAccessibility.PostNotification
				UIAccessibility.PostNotification (UIAccessibilityPostNotification.Announcement,new NSString(@"Item was deleted"));
			};

			TitleText.TextAlignment = UITextAlignment.Natural;
			NotesText.TextAlignment = UITextAlignment.Natural;
		}

		// this will be called before the view is displayed 
		public void SetTask (RootViewController d, TodoItem task) 
		{
			Delegate = d;
			currentTask = task;
		}

		// when displaying, set-up the properties
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			TitleText.Text = currentTask.Name;
			NotesText.Text = currentTask.Notes;
			DoneSwitch.On = currentTask.Done;
		}
	}
}