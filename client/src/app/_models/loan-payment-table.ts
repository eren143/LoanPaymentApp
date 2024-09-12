export interface LoanPaymentTable {
    id: number;
    totalNumPayments: number;
    rows: LoanPaymentRow[];
}

export interface LoanPaymentRow {
    id : number;
    paymentNumber: number;
    monthlyInstallment: number;
    principalPayment: number;
    interestPayment: number;
    remainingBalance: number;
}