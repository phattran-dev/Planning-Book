import { Component } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent {
  items = [
    { icon: '🖌️', title: 'Design Tasks', count: 3 },
    { icon: '💻', title: 'Development Tasks', count: 5 },
    { icon: '📝', title: 'Meeting Prep', count: 12 },
    { icon: '📚', title: 'Learning Goals', count: 3 },
    { icon: '👥', title: 'Team Collaboration', count: 4 },
    { icon: '🚀', title: 'Personal Development', count: 5 },
    { icon: '🖌️', title: 'Design Tasks', count: 3 },
  ];
}
