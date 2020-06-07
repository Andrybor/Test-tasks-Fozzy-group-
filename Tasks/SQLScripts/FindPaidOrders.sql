declare @customers table (id int, name nvarchar(20))
declare @orders table (id int, summa numeric(18,2), customerId int)
declare @payments table (customerId int, payment numeric(18,2))
 
insert @customers (id, name)
values
(1, N'Первый'),
(2, N'Второй'),
(3, N'Третий'),
(4, N'Четвертый')

insert @orders (id, summa, customerId)
values
(1, 10, 1),
(2, 15, 1),
(3, 20, 1),
(4, 25, 1),
(5, 12, 2),
(6, 14, 2),
(7, 200, 2),
(8, 100, 3),
(9, 200, 3)
insert @payments (customerId, payment)
values
(1, 30),
(2, 500),
(3, 100),
(4, 20)

select c.id as customer_id, c.name as customer_name
     , o.id as order_id, o.summa
     , max(o.slide_order_summ) over(partition by o.customerId) as total_order_summ
     , p.payment
     , p.payment - max(o.slide_order_summ) over(partition by o.customerId) as balance
  from @customers c
  join (select *, sum(summa) over(partition by customerId order by id) as slide_order_summ
           from @orders)o
      on c.id = o.customerId
  join @payments p
    on c.id = p.customerId
 where o.slide_order_summ <= p.payment
