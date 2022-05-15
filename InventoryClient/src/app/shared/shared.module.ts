import { NgModule } from '@angular/core'
import { SidebarComponent } from './sidebar/sidebar.component'
import { MaterialModule } from '../material/material.module'
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [SidebarComponent],
  imports: [MaterialModule, RouterModule],
  exports: [SidebarComponent]
})
export class SharedModule {}
