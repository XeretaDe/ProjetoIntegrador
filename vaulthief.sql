-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 15-Fev-2022 às 02:24
-- Versão do servidor: 10.4.22-MariaDB
-- versão do PHP: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `vaulthief`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `artigos`
--

CREATE TABLE `artigos` (
  `Id` int(255) NOT NULL,
  `Title` varchar(60) NOT NULL,
  `Description` varchar(752) NOT NULL,
  `Conteudo` longtext NOT NULL,
  `Imagem` varchar(255) NOT NULL,
  `FKuser` varchar(85) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `artigos`
--

INSERT INTO `artigos` (`Id`, `Title`, `Description`, `Conteudo`, `Imagem`, `FKuser`) VALUES
(14, 'Fusce luctus eleifend nibh at lacinia.', 'Donec a finibus nibh, posuere interdum arcu. Morbi ut purus et lacus vehicula tempus vel sit amet urna. ', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis hendrerit dolor. Donec sit amet feugiat lectus. Donec sollicitudin ante at augue maximus, eget consequat ante sollicitudin. Etiam lacus odio, interdum nec massa in, scelerisque molestie libero. Duis felis nulla, vehicula ut augue sit amet, bibendum placerat metus. Praesent magna arcu, bibendum fermentum lobortis ut, fermentum sit amet sapien. Aliquam blandit sit amet eros sit amet volutpat. Vestibulum quis risus leo. Fusce ac sapien in augue mollis viverra eu sit amet felis. Ut aliquet diam at magna fringilla, eget condimentum arcu pulvinar. Duis venenatis vestibulum massa, in ornare ipsum. Duis lectus enim, dignissim ac diam ac, tincidunt ultricies metus. Nam ornare ut diam in aliquet. Aliquam gravida nisl in venenatis facilisis. Etiam ultrices tempor arcu a efficitur. In tristique erat non nibh egestas, auctor cursus ligula posuere.  Fusce at nisl vitae ex bibendum sodales quis nec erat. Pellentesque cursus rhoncus mauris sed gravida. Sed rutrum ex quis congue pretium. Phasellus lacinia, nisi quis volutpat fermentum, nibh turpis pellentesque tortor, quis tristique urna tortor eu leo. Donec bibendum ullamcorper luctus. Morbi rutrum placerat elit, eget mollis risus venenatis vitae. Ut aliquet euismod aliquam. Quisque facilisis fermentum lacus at luctus. Fusce ac magna consectetur, pharetra felis quis, consectetur justo.  Fusce luctus eleifend nibh at lacinia. Donec et faucibus ipsum. Aliquam auctor dolor mollis, dignissim ligula vitae, euismod augue. Nulla urna arcu, feugiat a consequat id, mollis a tortor. Curabitur in ante tincidunt, porttitor lectus quis, tempor ex. Phasellus imperdiet iaculis eros. In ut tellus tellus. Nam hendrerit mattis est, non vehicula risus sollicitudin non. Pellentesque enim tortor, tristique quis lorem quis, volutpat vulputate dui. Maecenas condimentum quam ligula, at luctus augue accumsan vel.  Donec a finibus nibh, posuere interdum arcu. Morbi ut purus et lacus vehicula tempus vel sit amet urna. Proin ac sollicitudin leo. Aliquam facilisis consequat ex, at aliquet ante finibus sit amet. In a risus nisl. Suspendisse potenti. Donec semper risus nibh, et bibendum tortor lacinia sed. Suspendisse quis felis nisl. Maecenas sit amet nisi elit. Sed porttitor egestas lectus sit amet scelerisque.  Cras malesuada, turpis vitae congue vulputate, turpis libero cursus turpis, eu porttitor sem lectus a lacus. Nunc quam velit, ultricies nec tortor quis, malesuada sagittis velit. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer dapibus, lectus at sagittis semper, dui metus ullamcorper risus, a molestie purus magna sed ipsum. Integer ut interdum mi, ac faucibus est. Vivamus fringilla dui quis massa pretium, ut hendrerit mi dignissim. Mauris rutrum at arcu at imperdiet. Morbi accumsan, nunc a molestie volutpat, lorem erat aliquet augue, vel mattis justo dolor et massa.', '3a95003c-b243-4693-9bd4-d61e76959c67_tumblr_pcwxn5zV2q1xcnpsto1_1280.png', '367aa2e7-7ed4-4384-9ece-4ab4451ac675');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(85) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(85) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(85) DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(85) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(85) NOT NULL,
  `ProviderKey` varchar(85) NOT NULL,
  `ProviderDisplayName` text DEFAULT NULL,
  `UserId` varchar(85) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(85) NOT NULL,
  `RoleId` varchar(85) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(85) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(85) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(85) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` text DEFAULT NULL,
  `SecurityStamp` text DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `PhoneNumber` text DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('367aa2e7-7ed4-4384-9ece-4ab4451ac675', 'ronaldo@gmail.com', 'RONALDO@GMAIL.COM', 'Ronaldo Aragão', 'RONALDO ARAGÃO', 0, 'AQAAAAEAACcQAAAAEDyM7JJ2KzmWnjBrITLrN9YhexunUF+I4UGFWkWetK/wTOrUkD/OeODk8aciNRLnJg==', 'GSNDW6OSBZUPKIR45QU4HJ2TAYQUFF2A', '78412a40-7f0b-4588-a8f5-bf362057a98e', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(85) NOT NULL,
  `LoginProvider` varchar(85) NOT NULL,
  `Name` varchar(85) NOT NULL,
  `Value` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `reviews`
--

CREATE TABLE `reviews` (
  `Id` int(255) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `Description` varchar(100) NOT NULL,
  `Conteudo` longtext NOT NULL,
  `Image` varchar(255) NOT NULL,
  `Score` double NOT NULL,
  `User` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `reviews`
--

INSERT INTO `reviews` (`Id`, `Title`, `Description`, `Conteudo`, `Image`, `Score`, `User`) VALUES
(0, 'aaaa', 'aaaa', 'aaaaa', '07ecb325-ce64-427a-89f7-9f2f1829ccc1_tumblr_pcwxn5zV2q1xcnpsto1_1280.png', 10, '367aa2e7-7ed4-4384-9ece-4ab4451ac675');

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220206182151_initialcommit', '5.0.0');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `artigos`
--
ALTER TABLE `artigos`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Title` (`Title`),
  ADD KEY `FKuser` (`FKuser`);

--
-- Índices para tabela `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Índices para tabela `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Índices para tabela `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Índices para tabela `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Índices para tabela `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Índices para tabela `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Índices para tabela `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Índices para tabela `reviews`
--
ALTER TABLE `reviews`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Title` (`Title`),
  ADD UNIQUE KEY `User` (`User`);

--
-- Índices para tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `artigos`
--
ALTER TABLE `artigos`
  MODIFY `Id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de tabela `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `artigos`
--
ALTER TABLE `artigos`
  ADD CONSTRAINT `FKuser` FOREIGN KEY (`FKuser`) REFERENCES `aspnetusers` (`Id`);

--
-- Limitadores para a tabela `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `reviews`
--
ALTER TABLE `reviews`
  ADD CONSTRAINT `UserFK` FOREIGN KEY (`User`) REFERENCES `aspnetusers` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
