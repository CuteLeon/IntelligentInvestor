Refactored from https://github.com/CuteLeon/CleverStocker

# Intelligent Investor

<p align="center">
   <img src="https://raw.github.com/CuteLeon/IntelligentInvestor/master/Documents/IntelligentInvestor.png" align="center"/>
   <h2 align="center">Intelligent Investor</h2>
   <p align="center">A stock and quota system based on .Net 6.0</p>
</p>

## Status

<p align="center">
   <a href="https://github.com/CuteLeon/IntelligentInvestor/actions/workflows/dotnet-core.yml">
      <img border="0" src="https://github.com/CuteLeon/IntelligentInvestor/workflows/.Net%20Build/badge.svg" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/blob/master/LICENSE">
      <img border="0" src="https://img.shields.io/github/license/CuteLeon/IntelligentInvestor" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/search?l=c%23">
      <img border="0" src="https://img.shields.io/github/languages/top/CuteLeon/IntelligentInvestor" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/archive/refs/heads/master.zip">
      <img border="0" src="https://img.shields.io/github/repo-size/CuteLeon/IntelligentInvestor" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/issues?q=is%3Aopen+is%3Aissue">
      <img border="0" src="https://img.shields.io/github/issues/CuteLeon/IntelligentInvestor" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/network/members">
      <img border="0" src="https://img.shields.io/github/forks/CuteLeon/IntelligentInvestor" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/stargazers">
      <img border="0" src="https://img.shields.io/github/stars/CuteLeon/IntelligentInvestor" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/watchers">
      <img border="0" src="https://img.shields.io/github/watchers/CuteLeon/IntelligentInvestor" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/releases">
      <img border="0" src="https://img.shields.io/github/v/release/CuteLeon/IntelligentInvestor?include_prereleases" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/releases">
      <img border="0" src="https://img.shields.io/github/release-date-pre/CuteLeon/IntelligentInvestor" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/archive/refs/heads/master.zip">
      <img border="0" src="https://img.shields.io/github/downloads/CuteLeon/IntelligentInvestor/total" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/tags">
      <img border="0" src="https://img.shields.io/github/v/tag/CuteLeon/IntelligentInvestor" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/releases">
      <img border="0" src="https://img.shields.io/github/commits-since/CuteLeon/IntelligentInvestor/latest/master?include_prereleases" />
   </a>
   <a href="https://github.com/CuteLeon/IntelligentInvestor/commits/master">
      <img border="0" src="https://img.shields.io/github/last-commit/CuteLeon/IntelligentInvestor/master" />
   </a>
</p>

# Screen

![](https://raw.github.com/CuteLeon/IntelligentInvestor/master/Documents/Screen_1.jpg)

![](https://raw.github.com/CuteLeon/IntelligentInvestor/master/Documents/Screen_2.jpg)

![](https://raw.github.com/CuteLeon/IntelligentInvestor/master/Documents/Screen_3.jpg)

# Database Migration

## Setup

1. Select `IntelligentInvestor.Client` as Startup project;
2. Open Package Manager Console in Visual Studio;
3. Select `IntelligentInvestor.Infrastructure` as Default project in Package Manager Console;
4. Input commands and execute;

## Commands

| Command                  | Description                                                                                                 |
| ------------------------ | ----------------------------------------------------------------------------------------------------------- |
| Get-Help entityframework | Displays information about entity framework commands.                                                       |
| Add-Migration            | Creates a migration by adding a migration snapshot.                                                         |
| Remove-Migration         | Removes the last migration snapshot.                                                                        |
| Update-Database          | Updates the database schema based on the last migration snapshot.                                           |
| Script-Migration         | Generates a SQL script using all the migration snapshots.                                                   |
| Scaffold-DbContext       | Generates a DbContext and entity type classes for a specified database. This is called reverse engineering. |
| Get-DbContext            | Gets information about a DbContext type.                                                                    |
| Drop-Database            | Drops the database.                                                                                         |
