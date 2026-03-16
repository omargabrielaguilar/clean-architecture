S
O
L
I
D

--
Single Responsability
A cllas should have one and only one reason to change
<?php namespace Acme\Reporting;

use Auth, DB, Exception;

class SalesReporter {

    public function between($startDate, $endDate)
    {
        // perform authentication
        if ( ! Auth::check()) throw new Exception('Authentication required for reporting.');

        // get sales from db
        $sales = $this->queryDBForSalesBetween($startDate, $endDate);

        // return results
        return $this->format($sales);
    }

    protected function queryDBForSalesBetween($startDate, $endDate)
    {
        return DB::table('sales')->whereBetween('created_at', [$startDate, $endDate])->sum('charge');
    }
}
