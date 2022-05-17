import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core'
import { debounceTime, distinctUntilChanged, filter, map, Subject } from 'rxjs'

@Component({
  selector: 'app-input-search',
  templateUrl: './input-search.component.html',
  styles: []
})
export class InputSearchComponent implements OnInit {
  debouncer: Subject<string> = new Subject<string>()
  termino: string = ''

  @Input() placeholder: string = ''
  @Output() onDebounce: EventEmitter<string> = new EventEmitter<string>()

  ngOnInit () {
    this.debouncer
      .pipe(
        map(search => search.trim()),
        debounceTime(500),
        distinctUntilChanged(),
        filter(search => search !== '')
      )
      .subscribe(valor => this.onDebounce.emit(valor))
  }

  keyPress () {
    this.debouncer.next(this.termino)
  }
}
