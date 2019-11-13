# Public Browse Acceptance Tests

## Introduction
The Acceptance tests are an ongoing project that will be expanded to match the public browse site as it is being developed. It utilises Selenium Grid (See [here](https://www.seleniumhq.org/docs/07_selenium_grid.jsp) for more info) to ensure driver and browser versions and types are independent of the solution.

## Environment Variables
All environment variables used in this repo are at Process level (i.e. in the same console window as the `dotnet test` command is performed).

| Variable | Example | Default |
|---------------|------------------|------------------|
| BROWSER | `chrome` | `chrome-local`<sup>1</sup> |
| PBURL | `http://publicbrowse.nhs.net` | `http://10.0.75.1:3000`<sup>2</sup> |
| HUBURL | `http://localhost:4444/wd/hub` | `http://localhost:4444/wd/hub` |

To set a process level environment variable in a CLI see the below table

| CLI | Command | Example |
|---------------|--------------------|---------------
|`bash` | `export` | `export BROWSER=chrome` |
| `cmd` | `set` | `set BROWSER=chrome`|
| `PowerShell` | `$env:` | `$env:BROWSER = "chrome"` |

<sup>1</sup> - `chrome-local` should only be used for debugging. It will use the local instance of chrome rather than the Selenium Grid nodes to run the tests

<sup>2</sup> - `10.0.75.1:3000` is the external address when running the public browse site locally, this way the nodes in the hub can connect to it without issue

_Note_ - For these tests to run correctly against the public browse, the public browse site must be run with a NODE_ENV other than `development`. This will disable the browser sync module so parallel running tests do not interfere with each other

## Selenium Grid
Selenium grid is a distributed set of nodes linked to a master node that run the tests independently of each other then combine results. A docker-compose file has been provided to ease the setup of a grid, simply by running `docker-compose up -d`. THis will set up a very simple grid consisting of a hub, a chrome node and a firefox node. THe browser nodes can be scaled up by adding `--scale chrome=4` and/or `--scale firefox=4`, changing the value after the `=` symbol to however many nodes you require.

To close down the grid and stop the containers, simply run `docker-compose down --remove-orphans` and the grid will gracefully stop.