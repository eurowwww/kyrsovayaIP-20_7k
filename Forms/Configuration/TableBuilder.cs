using System.Collections.Generic;
using System.Data.SqlClient;

using Dmon.Model;

namespace Dmon
{
    internal class TableBuilder
    {
        private readonly SqlConnection _connection;

        public TableBuilder(SqlConnection connection)
        {
            _connection = connection;
        }

        public Table BuildCategoriesTable()
        {
            var configuration = new Dictionary<string, ColumnConfiguration>()
            {
                { "id", new ColumnConfiguration(ColumnDataType.Int, "Номер клиента", isPrimaryKey: true, isAutoField: true) },
                { "name", new ColumnConfiguration(ColumnDataType.String, "ФИО") },
                { "birthdate", new ColumnConfiguration(ColumnDataType.Date, "Дата рождения", isRequired: false ) },
                { "phone", new ColumnConfiguration(ColumnDataType.String, "Телефон") },
            };

            return new Table(_connection, "Clients", configuration);
        }

        public Table BuildProductsTable()
        {
            var configuration = new Dictionary<string, ColumnConfiguration>()
            {
                { "id", new ColumnConfiguration(ColumnDataType.Int, "Код авто", isPrimaryKey: true, isAutoField: true) },
                { "clientid", new ColumnConfiguration(ColumnDataType.Int, "Номер клиента") },
                { "markauto", new ColumnConfiguration(ColumnDataType.String, "Марка") },
                { "year", new ColumnConfiguration(ColumnDataType.Date, "Год") },
            };

            return new Table(_connection, "Autos", configuration);
        }

        public Table BuildStoresTable()
        {
            var configuration = new Dictionary<string, ColumnConfiguration>()
            {
                { "employee_id", new ColumnConfiguration(ColumnDataType.Int, "Код работника", isPrimaryKey: true, isAutoField: true) },
                { "name", new ColumnConfiguration(ColumnDataType.String, "ФИО") },
                { "birthdate", new ColumnConfiguration(ColumnDataType.Date, "Дата рождения") },
                { "experience", new ColumnConfiguration(ColumnDataType.Int, "Стаж") },
                { "post", new ColumnConfiguration(ColumnDataType.String, "Должность") },
            };

            return new Table(_connection, "Employees", configuration);
        }

        public Table BuildProductToStoreTable()
        {
            var configuration = new Dictionary<string, ColumnConfiguration>()
            {
                { "order_id", new ColumnConfiguration(ColumnDataType.Int, "Номер заказ", isPrimaryKey: true, isAutoField: true) },
                { "creation_date", new ColumnConfiguration(ColumnDataType.Date, "Дата") },
                { "clientid", new ColumnConfiguration(ColumnDataType.Int, "Номер клиента") },
                { "price", new ColumnConfiguration(ColumnDataType.Double, "Цена") },
                { "employee_id", new ColumnConfiguration(ColumnDataType.Int, "Код работника") }
            };

            return new Table(_connection, "Orders", configuration);
        }

        public Table BuildUsersTable()
        {
            var configuration = new Dictionary<string, ColumnConfiguration>()
            {
                { "username", new ColumnConfiguration(ColumnDataType.String, "Имя", isPrimaryKey: true) },
                { "password", new ColumnConfiguration(ColumnDataType.String, "Пароль") },
            };

            return new Table(_connection, "Users", configuration);
        }

        public Table BuildRolesTable()
        {
            var configuration = new Dictionary<string, ColumnConfiguration>()
            {
                { "name", new ColumnConfiguration(ColumnDataType.String, "Роль", isPrimaryKey: true) },
                { "permissions", new ColumnConfiguration(ColumnDataType.Int, "Права(bit flags)") },
            };

            return new Table(_connection, "Roles", configuration);
        }

        public Table BuildRoleToUserTable()
        {
            var configuration = new Dictionary<string, ColumnConfiguration>()
            {
                { "userName", new ColumnConfiguration(ColumnDataType.String, "Пользователь", isPrimaryKey: true) },
                { "roleName", new ColumnConfiguration(ColumnDataType.String, "Роль", isPrimaryKey: true) },
            };

            return new Table(_connection, "RoleToUser", configuration);
        }

        public Table BuildRoleToTableTable()
        {
            var configuration = new Dictionary<string, ColumnConfiguration>()
            {
                { "roleName", new ColumnConfiguration(ColumnDataType.String, "Роль", isPrimaryKey: true) },
                { "tableName", new ColumnConfiguration(ColumnDataType.String, "Таблица", isPrimaryKey: true) },
                { "permissions", new ColumnConfiguration(ColumnDataType.Int, "Права(bit flags)") },
            };

            return new Table(_connection, "RoleToTable", configuration);
        }
    }
}
