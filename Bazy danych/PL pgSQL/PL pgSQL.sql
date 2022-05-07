# 1 ------------------------
do $$
declare
	d date := current_date;
	u varchar := current_user;
	b u%type := current_database();
begin
	raise notice 'Jest dziś %, pracujesz na bazie danych % jako użytkownik %', d, u, b;
end $$

# 2 ------------------------
do $$
begin
	for x in 1..100 loop
		if 100 % x = 0 then
			raise notice '%', x;
		end if;
	end loop;
end $$

# 3 ------------------------
do $$
declare
	d date := current_date;
	endD date := '2025-12-31';
begin
	while d <= endD loop
		if extract(dow from d) = 5 and extract(day from d) = 13 then
			raise notice '%', d;
		end if;
		d := d + 1;
	end loop;
end $$

# 4 ------------------------
create table cars (
	c_id integer,
	make varchar(20),
	model varchar(20),
	price float,
	description char(250)
);

# 5 ------------------------
do $$ 
declare
	make varchar[] := array['porsche', 'mercedes', 'mercedes', 'audi', 'audi', 'audi', 'bmw', 'bmw', 'bmw', 'mercedes'];
	model varchar[] := array['911','e','glc', 'a4', 'a6', 'q5', '3', '5', 'x3', 'c'];
	random_index integer;
	c_id integer;
	price integer;
begin 
	for i in 1..10 loop
		-- c_id
		c_id := i;
		-- losowy index tablicy + marka i model
 		random_index := ROUND(RANDOM()*9+1);
		-- losowa cena (1000-100000)
		price := FLOOR(RANDOM()* (100000-1000 + 1) + 1000);
		insert into cars values (c_id, make[random_index], model[random_index], price,  '*** wygenerowane ***');
	end loop;
end $$;

# 6 ------------------------ (musi byc tabela cars z zad 4)
create or replace procedure generate_cars(in n integer) language plpgsql as $$
declare
	make varchar[] := array['porsche', 'mercedes', 'mercedes', 'audi', 'audi', 'audi', 'bmw', 'bmw', 'bmw', 'mercedes'];
	model varchar[] := array['911','e','glc', 'a4', 'a6', 'q5', '3', '5', 'x3', 'c'];
	random_index integer;
	c_id integer;
	price integer;
begin 
	for i in 1..n loop
		-- c_id
		c_id := i;
		-- losowy index tablicy + marka i model
 		random_index := ROUND(RANDOM()*9+1);
		-- losowa cena (1000-100000)
		price := FLOOR(RANDOM()* (100000-1000 + 1) + 1000);
		insert into cars values (c_id, make[random_index], model[random_index], price,  '*** wygenerowane ***');
	end loop;
end $$;

call generate_cars(20);
select * from cars;

# 7 ------------------------
create or replace procedure show_car(in id integer) language plpgsql as $$
declare
	v_querry varchar;
	r_car record;
begin 
	select * into strict r_car from cars where cars.c_id=id;
	raise notice '%, %, %, %, %', r_car.c_id, r_car.make, r_car.model, r_car.price, r_car.description;
exception
	when no_data_found then
		raise notice 'brak takiego pojazdu';
end $$;

call show_car(1); -- 1, audi, a4, 34473, *** wygenerowane ***
call show_car(3); -- 3, audi, a4, 51025, *** wygenerowane ***
call show_car(5); -- 5, bmw, 5, 80956, *** wygenerowane ***
call show_car(99); -- brak takiego pojazdu
call show_car(999); -- brak takiego pojazdu
call show_car(9999); -- brak takiego pojazdu

# 8 ------------------------
create table employees(
	e_id serial,
	first_name varchar(20),
	last_name varchar(20),
	salary float
);

insert into employees (first_name, last_name, salary)
values ('Dalai', 'Lama', 0), ('Elon', 'Musk', 1500000), 
('Jane', 'Doe', 250000), ('John', 'Doe', 25000);


# 9 ------------------------
create function kwota_wolna (brutto float) returns float language plpgsql as $$
declare
	kwota_wolna float;
begin
	if brutto <= 8000 then
		kwota_wolna := 1360;
	elsif brutto > 8000 and brutto <= 13000 then
		kwota_wolna := 1360 - 834.88 * (brutto - 8000) / 5000;
	elsif brutto >  13000 and brutto <= 85528 then
		kwota_wolna := 525.12;
	elsif brutto > 85528 and brutto <= 127000 then
		kwota_wolna := 525.12 - 525.12 * (brutto - 85528) / 41472;
	else
		kwota_wolna := 0;
	end if;
	return kwota_wolna;
end $$;

select first_name, salary, kwota_wolna(salary) from employees;


# 10 ------------------------
create function pit(brutto float) returns float language plpgsql as $$
declare
	pit float;
begin
	if brutto <= 85528 then
		pit := 0.17 * brutto - kwota_wolna(brutto);
	elsif brutto > 85528 and brutto <= 1000000 then
		pit := 14539.76 + 0.32 * (brutto - 85528) - kwota_wolna(brutto);
	elsif brutto >  1000000 then
		pit := 14539.76 + 0.32 * (brutto - 85528) - kwota_wolna(brutto) + 0.04 * (brutto - 1000000);
	end if;

	if pit < 0 then
		pit := 0;
	end if;
	return pit;
end $$;

select first_name, salary, pit(salary) from employees;

# 16 ------------------------
create or replace function EMP_TRG_PROC() returns trigger as $$
begin
	if new.salary is null or new.salary < 0 then
		raise notice 'Salary nie moze miec wartosci null, a takze nie moze byc mniejsze od 0. ';
		return null;
	else
		raise notice 'Rekord OK. % -> % i % -> %', new.first_name, INITCAP(new.first_name), new.last_name, UPPER(new.last_name);
		new.first_name := INITCAP(new.first_name);
		new.last_name := UPPER(new.last_name);
		return new;
	end if;
end $$ language plpgsql;

create or replace trigger EMP_TRG  before insert on employees 
for each row 
execute function EMP_TRG_PROC();

insert into employees (first_name, last_name, salary)
values ('john', 'rockefeller', 500);
insert into employees (first_name, last_name, salary)
values ('Teresa', 'Bojaxhiu', -500);

# 17 ------------------------
create table emp_log(
 op_time timestamp,
 op_user varchar(20),
 operation varchar(6),
 old_id integer,
 old_first_name varchar(20),
 old_last_name varchar(20),
 old_salary float,
 new_id integer,
 new_first_name varchar(20),
 new_last_name varchar(20),
 new_salary float
);

# 18 ------------------------
create or replace function EMP_TRG_PROC() returns trigger as $$
begin
	insert into emp_log
	values (current_timestamp, current_user, tg_op, 
		old.e_id, old.first_name, old.last_name, old.salary,
		new.e_id, new.first_name, new.last_name, new.salary);
	return new;
end $$ language plpgsql;

create or replace trigger EMP_TRG after insert or update or delete on employees 
for each row 
execute function EMP_TRG_PROC();

insert into employees (first_name, last_name, salary)
values ('john', 'rockefeller', 0);
update employees set first_name = 'jack', last_name = 'sparrow', salary = 12345;
delete from employees where employees.e_id >4;
