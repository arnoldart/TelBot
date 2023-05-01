import { Telegraf } from "telegraf"
import {message} from 'telegraf/filters'
import * as dotenv from "dotenv"

dotenv.config()

const bot = new Telegraf(process.env.BOT_TOKEN)

bot.on(message('text'), async (ctx) => {
  await ctx.reply(`Hello ${ctx.update.message.from.first_name}`);
});


bot.launch()