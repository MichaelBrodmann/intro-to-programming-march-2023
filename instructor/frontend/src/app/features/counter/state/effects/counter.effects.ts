import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs';
import { selectCounterBranch } from '..';
import { counterEvents } from '../actions/counter.actions';
@Injectable()
export class CounterEffects {
  // logItAll$ = createEffect(
  //   () => {
  //     return this.actions$.pipe(tap((action) => console.log(action.type))); // =>
  //   },
  //   { dispatch: false },
  // );

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
