import { Routes, RouterModule } from '@angular/router';
import { ListsComponent } from './lists/lists.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guard/auth.guard';
export const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'list', component: ListsComponent },
      {path: 'memberlist', component: MemberListComponent },
      {path: 'message', component: MessagesComponent }
    ]
  },

  {path: '**', redirectTo: 'home', pathMatch: 'full'}
];
// export const AppRouteRoutes = RouterModule.forRoot(routes);
