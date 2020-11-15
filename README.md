# :truck: cargomanager

CargoManager!

This is a prototype for a personal project started in 2016.

The goal was to create a "sharing economy" like solution for ground trasport.
Transport employees move cargos between cities. But once the cargo is delivered, many times they return without any other cargo (empty truck), with the associated cost and CO2 emissions.
The idea was to create an application to publish "cargo" offers and allow transport employees to bid for the cargo. This way transport employees could yield a profit the way back.

This project aimed to provide the backend services for the given application. Right now it provides two endpoints:
 * GET /cargos/: Retrieve the list of existing cargos
 * POST /cargos/_search: Search cargos by advanced criteria (price, volume, weight, origin and destination geographical area, date of departure and delivery, etc)

The backend uses Elasticsearch as a DB and search engine.

#### Unfortunately there is already some existing solutions like [Ontruck](https://www.ontruck.com/). So, don't expext that much from this project.
#### Anyway, it was a nice try!
