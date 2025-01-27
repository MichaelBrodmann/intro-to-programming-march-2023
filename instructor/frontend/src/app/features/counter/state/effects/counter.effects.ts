import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';

import { map, tap, filter } from 'rxjs';
import { selectCounterBranch } from '..';
import {
  counterCommands,
  counterDocuments,
  counterEvents,
} from '../actions/counter.actions';
import { CounterState } from '../reducers/counter.reducer';
@Injectable()
export class CounterEffects {
  // logItAll$ = createEffect(
  //   () => {
  //     return this.actions$.pipe(tap((action) => console.log(action.type))); // =>
  //   },
  //   { dispatch: false },
  // );

  // when we are TOLD to load the counter state, check local storage, if it's there, dispatch a document with that data,
  // if it isn't, do nothing.
  loadCounterState$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(counterCommands.loadCounterState), // it either stops here or it is a loadCounterState
      map(() => localStorage.getItem('counter-state')), // string | null
      filter((storedValue) => storedValue !== null), // stop here if it's null - we'll stick with initialState => string
      // eslint-disable-next-line @typescript-eslint/no-non-null-assertion
      map((theString) => JSON.parse(theString!) as CounterState), // type coercions are a MAJOR code smell
      map((counterState) =>
        counterDocuments.counterState({ payload: counterState }),
      ), // the action to send to the store.
    );
  });

  // Every time an action of type increment, decrement, reset, countBySet happens...
  // write the counter state to localstorage.

  writeCounterState$ = createEffect(
    () => {
      return this.actions$.pipe(
        ofType(
          counterEvents.countBySet,
          counterEvents.decrementButtonClicked,
          counterEvents.incrementButtonClicked,
          counterEvents.resetButtonClicked,
        ),
        concatLatestFrom(() => this.store.select(selectCounterBranch)), // { current: 99, by: 5}
        tap(
          ([
            ,
            data,
          ]) => localStorage.setItem('counter-state', JSON.stringify(data)),
        ),
      );
    },
    { dispatch: false },
  );
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store,
  ) {}
}
