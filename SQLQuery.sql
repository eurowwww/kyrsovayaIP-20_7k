begin transaction;

create table Clients(
	id bigint identity(1,1) primary key, 
	name nvarchar(128) not null, 
	birthdate date,
	phone char(11) not null, 
);

create table Autos (
	id bigint identity(1,1) primary key, 
	clientid bigint foreign key references Clients(id) not null, 
	markauto nvarchar(128) not null, 
	year date not null, 
);

create table Employees(
	employee_id bigint identity(1,1) primary key, 
	name nvarchar(128) not null, 
	birthdate date not null,
	experience int not null,
	post nvarchar(128) not null,
);

create table Orders (
	order_id bigint identity(1,1) primary key, 
	creation_date date not null,
	clientid bigint foreign key references Clients(id) not null, 
	price money not null,
	employee_id bigint foreign key references Employees(employee_id) not null, 
);












create table Users(
	username nvarchar(128) primary key,
	password nvarchar(64) not null,
);

create table Roles(
	name nvarchar(128) primary key,
	permissions int not null
);

create table RoleToUser(
	userName nvarchar(128) foreign key references Users(username),
	roleName nvarchar(128) foreign key references Roles(name),
	primary key (userName, roleName)
);

create table RoleToTable(
	roleName nvarchar(128) foreign key references Roles(name),
	tableName varchar(128) not null,
	permissions int not null,
	primary key (tableName, roleName)
);

insert into Users values ('admin', 'admin');
insert into Roles values ('sa', 3);
insert into RoleToUser values ('admin', 'sa');
insert into RoleToTable values ('sa', 'Clients', 3);
insert into RoleToTable values ('sa', 'Autos', 3);
insert into RoleToTable values ('sa', 'Employees', 3);
insert into RoleToTable values ('sa', 'Orders', 3);
insert into RoleToTable values ('sa', 'Roles', 3);
insert into RoleToTable values ('sa', 'Users', 3);
insert into RoleToTable values ('sa', 'MemberToPlay', 3);
insert into RoleToTable values ('sa', 'RoleToUser', 3);
insert into RoleToTable values ('sa', 'RoleToTable', 3);

commit;