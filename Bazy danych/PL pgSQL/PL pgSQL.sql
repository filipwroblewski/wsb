# 1
do $$
declare
	d date := current_date;
	u varchar := current_user;
	b u%type := current_database();
begin
	raise notice 'Jest dziś %, pracujesz na bazie danych % jako użytkownik %', d, u, b;
end $$

# 2
do $$
begin
	for x in 1..100 loop
		if 100 % x = 0 then
			raise notice '%', x;
		end if;
	end loop;
end $$

# 3
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

# 4
create table cars (
	c_id integer,
	make varchar(20),
	model varchar(20),
	price float,
	description char(250)
);

# 5
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
