namespace Bulky.Utility
{
	public static class SD
	{
		public const string Role_Customer = "Customer";
		public const string Role_Company = "Company";
		public const string Role_Admin = "Admin";
		public const string Role_Employee = "Employee";


		public const string StatusPending = "Pending"; //В ожидании
		public const string StatusApproved = "Approved"; //Одобренный
		public const string StatusInProcess = "Processing";
		public const string StatusShipped = "Shipped"; //Отправленный
		public const string StatusCancelled = "Cancelled";
		public const string StatusRefunded = "Refunded"; //Возмещено

		public const string PaymentStatusPending = "Pending"; //Статус платежа Ожидается
		public const string PaymentStatusApproved = "Approved"; //Статус платежа одобрен
		public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment"; //Статус платежа Отложенный платеж
		public const string PaymentStatusRejected = "Rejected"; //Статус платежа отклонен
	}
}
